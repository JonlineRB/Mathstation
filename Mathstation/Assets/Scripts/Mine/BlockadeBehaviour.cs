using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockadeBehaviour : MonoBehaviour
{
    [SerializeField]
    private float finalPosition;
    private float initialPosition;
    private float timeElapsed;
    [SerializeField]
    private float lerpDuration;
    [SerializeField]
    private float blinkDuration;
    [SerializeField]
    private int blinkAmt;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //lerp
        transform.position =new Vector3(Mathf.Lerp(initialPosition,finalPosition, timeElapsed / lerpDuration), transform.position.y,transform.position.z);
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= lerpDuration && GameObject.Find("Cannon"))
            BlowUp();

    }

    public void BlowUp(){
        // Debug.Log("DING");
        // StartCoroutine("DestructionSequence");
        GameObject.Find("Cannon").GetComponent<SpriteSwap>().InitSwap();
        transform.position = new Vector3(initialPosition, transform.position.y, transform.position.z);
        gameObject.SetActive(false);
    }

    private IEnumerator DestructionSequence(){
        for(int i = 0; i < blinkAmt; i++){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0f);
            yield return new WaitForSeconds(blinkDuration);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
            yield return new WaitForSeconds(blinkDuration);
        }


        //reset positoin, deactivate
        transform.position = new Vector3(initialPosition, transform.position.y, transform.position.z);
        gameObject.SetActive(false);
    }
}
