using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Player controls script for the explore game
public class ExplorePlayerControls : MonoBehaviour
{
    
    private float currentVelocity;
    [SerializeField] private List<float> velocities;
    private int velocityIndex = 0;

    [SerializeField]
    private GameObject leadingObject; //Set to the movement marker. Player will move towards this
    [SerializeField]
    private float stopDistance;
    //GUI elements
    [SerializeField] private GameObject velocityText;
    [SerializeField] private GameObject velocityPanel;

    void Start(){
        //Set starting velocity
        currentVelocity = velocities[0];
        velocityText.GetComponent<Text>().text = ((int)currentVelocity).ToString();
    }


    void Update(){
        //While target marker is active and above distance threshold, move there
        if(leadingObject.activeSelf && Vector3.Distance(transform.position, leadingObject.transform.position) > stopDistance){
            gameObject.GetComponent<Fuel>().SetConsuming(true);
            float lookAngle = Vector2.SignedAngle(transform.up, (leadingObject.transform.position - transform.position).normalized);
            transform.Rotate(new Vector3(0,0,lookAngle));
            transform.Translate(Vector3.up * currentVelocity * Time.deltaTime ,Space.Self);
        }
    }
    //Speed up, invoked when the player consumes a speed up ring
    public void SpeedUp(){
        if(velocities.Count > velocityIndex + 1){
            currentVelocity = velocities[++velocityIndex];
        }

        //update UI elements
        velocityPanel.GetComponent<VelocityPanel>().SpeedUp(((int)currentVelocity).ToString());

        //log the speedup upgrade
        gameObject.GetComponent<UpgradeLog>().SpeedUp();    
    }
}
