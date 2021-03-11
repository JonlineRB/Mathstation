using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRingInterpolation : MonoBehaviour
{
    [SerializeField] private float duration_1;
    [SerializeField] private float duration_2;
    [SerializeField] private float distance_2;
    [SerializeField] private float intermission;
    private GameObject currentRing;
    
    public void Init1stInterpolation(Vector3 position, GameObject ring){
        currentRing = ring;
        StartCoroutine(Interpolation_1(position));
        gameObject.GetComponent<MoveLock>().setMoveLock(true);
    }

    private IEnumerator Interpolation_1(Vector3 position){ //initial interpolation, get into position before flying through the ring
        float elapsed = 0;

        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        while(elapsed < duration_1){

            transform.rotation = Quaternion.Lerp(currentRotation, Quaternion.identity, elapsed / duration_1);

            transform.position = Vector3.Lerp(currentPosition, position, elapsed / duration_1);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = position;
        transform.rotation = Quaternion.identity;

        //call math here, rest depends on correct solving

        //intermission
        yield return new WaitForSeconds(intermission);

        //call the next interpolation
        StartCoroutine("Interpolation_2");
    }

    private IEnumerator Interpolation_2(){ //2nd interpolation, fly through the ring and consume it
        currentRing.GetComponent<Ring>().StartCoroutine("Consume");
        float elapsed = 0;

        Vector3 currentPosition = transform.position;
        Vector3 finPosition = currentPosition + new Vector3(0, distance_2, 0);

        while(elapsed < duration_2){

            transform.position = Vector3.Lerp(currentPosition, finPosition, elapsed / duration_2);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = finPosition;
        gameObject.GetComponent<MoveLock>().setMoveLock(false);
    }
}
