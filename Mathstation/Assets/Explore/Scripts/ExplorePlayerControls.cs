using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerControls : MonoBehaviour
{
    [SerializeField]
    private float maxVelocity;

    [SerializeField]
    private GameObject leadingObject;
    [SerializeField]
    private float stopDistance;


    void Update(){
        if(leadingObject.activeSelf && Vector3.Distance(transform.position, leadingObject.transform.position) > stopDistance){
            float lookAngle = Vector2.SignedAngle(transform.up, (leadingObject.transform.position - transform.position).normalized);
            // transform.Rotate(new Vector3(0,0,lookAngle * Time.deltaTime));
            transform.Rotate(new Vector3(0,0,lookAngle));
            transform.Translate(Vector3.up * maxVelocity * Time.deltaTime ,Space.Self);
        }
    }
}
