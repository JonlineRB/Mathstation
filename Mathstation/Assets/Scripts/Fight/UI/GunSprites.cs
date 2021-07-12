using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSprites : MonoBehaviour
{

    private bool alternator = true;

    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;

    [SerializeField] private Sprite leftIdle;
    [SerializeField] private Sprite leftFire;
    [SerializeField] private Sprite rightIdle;
    [SerializeField] private Sprite rightFire;
    [SerializeField] private float duration;
    [SerializeField] private bool locked;

    void Update(){
        if(Input.GetMouseButtonDown(0) && !locked){
            if(alternator){
                leftGun.GetComponent<Image>().sprite = leftFire;
                StartCoroutine(RestoreGun(true));
            }
            else{
                rightGun.GetComponent<Image>().sprite = rightFire;
                StartCoroutine(RestoreGun(false));
            }
            alternator = !alternator;
        }
    }

    public void Lock(){
        locked = true;
    }

    public void Unlock(){
        locked = false;
    }

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
