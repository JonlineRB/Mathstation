using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRing : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowDistance;
    [SerializeField] private List<GameObject> fadies;
    // [SerializeField] private bool active = false;
    [SerializeField] private GameObject[] pointingAt;

    void Start(){
        foreach(GameObject pointee in pointingAt){
            //instantiate an arrow
            //add it to the list of fade objects
            Vector3 direction = (pointee.transform.position - transform.position).normalized;
            GameObject arrowInstance = GameObject.Instantiate(arrow, transform.position + direction * arrowDistance,
            Quaternion.Euler(0,0,Vector3.SignedAngle(Vector3.up, direction, Vector3.forward)), transform);
            fadies.Add(arrowInstance);
        }
    }
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
