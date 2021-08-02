using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSprites : MonoBehaviour
{

    private bool alternator = true; // Used to alternate between the two guns that can fire

    // Visual object references
    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;

    // Sprite references
    [SerializeField] private Sprite leftIdle;
    [SerializeField] private Sprite leftFire;
    [SerializeField] private Sprite rightIdle;
    [SerializeField] private Sprite rightFire;

    // Duration of fire sprite
    [SerializeField] private float duration;

    // Simple lock
    [SerializeField] private bool locked;

    
    void Update(){

        // Initiate a firing effect on the visual objects
        if(Input.GetMouseButtonDown(0) && !locked){
            if(alternator){
                leftGun.GetComponent<Image>().sprite = leftFire;
                StartCoroutine(RestoreGun(true));
            }
            else{
                rightGun.GetComponent<Image>().sprite = rightFire;
                StartCoroutine(RestoreGun(false));
            }

            // Change alternator value
            alternator = !alternator;
        }
    }

    public void Lock(){
        locked = true;
    }

    public void Unlock(){
        locked = false;
    }

    // Coroutine manages switching the visual object's sprites
    // @param isLeftGun dictates if the coroutine is applied to left gun when true
    // and to right gun when false
    IEnumerator RestoreGun(bool isLeftGun){
        float elapsed = 0;
        while(elapsed < duration){
            elapsed += Time.deltaTime;
            yield return null;
        }
        if(isLeftGun)
            leftGun.GetComponent<Image>().sprite = leftIdle;
        else
            rightGun.GetComponent<Image>().sprite = rightIdle;
    }

}
