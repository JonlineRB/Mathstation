﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script handles the interpolations performed by the player when approaching upgrade rings
// and when consuming them.
public class PlayerRingInterpolation : MonoBehaviour
{
    //Fields for the respective interpolations
    [SerializeField] private float duration_1;
    [SerializeField] private float duration_2;
    [SerializeField] private float distance_2;
    [SerializeField] private float intermission;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float cameraDistance;
    private float cameraOGSize;
    private GameObject currentRing;

    void Start(){
        cameraOGSize = mainCamera.GetComponent<Camera>().orthographicSize;
    }
    
    public void Init1stInterpolation(Vector3 position, GameObject ring){
        currentRing = ring;
        StartCoroutine(Interpolation_1(position));
        gameObject.GetComponent<MoveLock>().IncrementMoveLock();
        gameObject.GetComponent<Reset>().IncrementLockReset();
    }

    private IEnumerator Interpolation_1(Vector3 position){ //initial interpolation, get into position before flying through the ring
        float elapsed = 0;

        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        while(elapsed < duration_1){

            transform.rotation = Quaternion.Lerp(currentRotation, Quaternion.identity, elapsed / duration_1);

            transform.position = Vector3.Lerp(currentPosition, position, elapsed / duration_1);

            mainCamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(cameraOGSize, cameraOGSize - cameraDistance, elapsed / duration_1);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = position;
        transform.rotation = Quaternion.identity;
        mainCamera.GetComponent<Camera>().orthographicSize = cameraOGSize - cameraDistance;

        // intermission
        yield return new WaitForSeconds(intermission);

        //call math here, rest depends on correct solving
        currentRing.GetComponent<Ring>().CallMathEditor();
    }

    public IEnumerator Interpolation_2(){ //2nd interpolation, fly through the ring and consume it
        currentRing.GetComponent<Ring>().StartCoroutine("Consume");
        float elapsed = 0;
        // intermission
        yield return new WaitForSeconds(intermission);

        Vector3 currentPosition = transform.position;
        Vector3 finPosition = currentPosition + new Vector3(0, distance_2, 0);

        while(elapsed < duration_2){

            transform.position = Vector3.Lerp(currentPosition, finPosition, elapsed / duration_2);

            elapsed += Time.deltaTime;

            mainCamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(cameraOGSize - cameraDistance, cameraOGSize, elapsed / duration_2);

            yield return null;
        }

        transform.position = finPosition;
        mainCamera.GetComponent<Camera>().orthographicSize = cameraOGSize;
        gameObject.GetComponent<MoveLock>().DecrementMoveLock();
        gameObject.GetComponent<Reset>().DecrementLockReset();
    }
}
