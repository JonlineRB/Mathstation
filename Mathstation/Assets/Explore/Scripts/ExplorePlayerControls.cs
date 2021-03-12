using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorePlayerControls : MonoBehaviour
{
    
    private float currentVelocity;
    [SerializeField] private List<float> velocities;
    private int velocityIndex = 0;

    [SerializeField]
    private GameObject leadingObject;
    [SerializeField]
    private float stopDistance;

    void Start(){
        currentVelocity = velocities[0];
    }


    void Update(){
        if(leadingObject.activeSelf && Vector3.Distance(transform.position, leadingObject.transform.position) > stopDistance){
            gameObject.GetComponent<Fuel>().SetConsuming(true);
            float lookAngle = Vector2.SignedAngle(transform.up, (leadingObject.transform.position - transform.position).normalized);
            transform.Rotate(new Vector3(0,0,lookAngle));
            transform.Translate(Vector3.up * currentVelocity * Time.deltaTime ,Space.Self);
        }
    }

    public void SpeedUp(){
        if(velocities.Count > velocityIndex + 1){
            currentVelocity = velocities[++velocityIndex];
        }
    }
}
