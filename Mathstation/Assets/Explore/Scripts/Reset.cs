using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script handles player position resets, such as when the fuel runs out
public class Reset : MonoBehaviour
{
    // Interpolation related fields
    [SerializeField] private Vector3 restartLocation;
    [SerializeField] private GameObject moveMarker;
    [SerializeField] private float duration;
    private Color ogColor = Color.white;
    [SerializeField] private Color resetColor;

    // Lock related field and methods. Has an incremental lock like player movement

    [SerializeField] private int resetLock = 0;

    public void IncrementLockReset(){
        resetLock++;
    }

    public void DecrementLockReset(){
        resetLock = Mathf.Max(--resetLock, 0);
    }

    //keyboard shortcut
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            InitReset();
        }
    }
    

    // Initialize the reset sequence, start coroutine
    public void InitReset(){
        if(resetLock > 0)
            return;
        //disable trail particle FX
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<MoveLock>().IncrementMoveLock();
        StartCoroutine("SmoothReset");
        gameObject.GetComponent<Fuel>().ResetFuel();
        gameObject.GetComponent<Fuel>().SetConsuming(false);
        moveMarker.SetActive(false);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = resetColor;
    }

    // Reset coroutine
    private IEnumerator SmoothReset(){
        float elapsedTime = 0;
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        while(elapsedTime <= duration){
            transform.position = Vector3.Lerp(currentPosition, restartLocation, elapsedTime / duration);
            transform.rotation = Quaternion.Lerp(currentRotation, Quaternion.identity, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = restartLocation;
        transform.rotation = Quaternion.identity;
        gameObject.GetComponent<MoveLock>().DecrementMoveLock();
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = ogColor;
        //enable trail particle FX
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
