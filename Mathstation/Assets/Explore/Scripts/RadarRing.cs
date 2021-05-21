using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRing : MonoBehaviour
{
    [SerializeField] private GameObject[] fadies;
    void OnTriggerEnter2D(Collider2D other){
        foreach(GameObject fadie in fadies){
            fadie.GetComponent<ConditionFade>().InitFadeIn();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        foreach(GameObject fadie in fadies){
            fadie.GetComponent<ConditionFade>().InitFadeOut();
        }
    }
}
