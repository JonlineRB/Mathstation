using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRing : MonoBehaviour
{
    [SerializeField] private GameObject[] fadies;
    // [SerializeField] private bool active = false;
    void OnTriggerEnter2D(Collider2D other){
        // if(!active){
        //     other.GetComponent<ArtifactInterpolation>().InitInterpolation(transform.position);
        //     foreach(GameObject fadie in fadies){
        //         fadie.GetComponent<ConditionFade>().InitFadeIn();
        //     }
        // }

        
        other.GetComponent<ArtifactInterpolation>().InitInterpolation(transform.position);
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
