using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    [SerializeField] private Vector3 restartLocation;
    [SerializeField] private GameObject moveMarker;
    [SerializeField] private float duration;
    

    public void InitReset(){
        StartCoroutine("SmoothReset");
        transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Fuel>().ResetFuel();
        gameObject.GetComponent<Fuel>().SetConsuming(false);
        moveMarker.SetActive(false);
    }

    private IEnumerator SmoothReset(){
        float elapsedTime = 0;
        Vector3 currentPosition = transform.position;

        while(elapsedTime <= duration){
            transform.position = Vector3.Lerp(currentPosition, restartLocation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = restartLocation;
    }
}
