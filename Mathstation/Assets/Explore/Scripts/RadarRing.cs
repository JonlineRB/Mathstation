using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRing : Artifact_Super
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowDistance;
    [SerializeField] private List<GameObject> fadies;
    [SerializeField] private GameObject[] pointingAt;
    [SerializeField] private GameObject dial;


    protected override void Action()
    {
        Scan();
    }

    protected override void Resolve()
    {
        dial.GetComponent<Rotate>().enabled = true;
    }

    protected override void Exit()
    {
        foreach(GameObject fadie in fadies){
            fadie.GetComponent<ConditionFade>().InitFadeOut();
        }
    }

    private void Scan(){
        fadies = new List<GameObject>();
        fadies.Add(background);
        foreach(GameObject pointee in pointingAt){
            if(!pointee.activeSelf)
                continue;
            //instantiate an arrow
            Vector3 direction = (pointee.transform.position - transform.position).normalized;
            GameObject arrowInstance = GameObject.Instantiate(arrow, transform.position + direction * arrowDistance,
            Quaternion.Euler(0,0,Vector3.SignedAngle(Vector3.up, direction, Vector3.forward)), transform);
            //add it to the list of fade objects
            fadies.Add(arrowInstance);
        }
        foreach(GameObject fadie in fadies){
            fadie.GetComponent<ConditionFade>().InitFadeIn();
        }
    }
}
