using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private float rate;
    [SerializeField]
    private GameObject textObject;
    private float journey;
    private bool engineDeployed;
    private bool blockade = false;
    private bool engineStopped = false;
    [SerializeField]
    private GameObject engineObject;

    void Update(){
        if(!engineDeployed || blockade || engineStopped)
            return;
        journey += rate * Time.deltaTime;
        //check for events here
        gameObject.GetComponent<Obstacles>().CheckEvent((int)journey);
        journey = Mathf.Clamp(journey, 0f, 100f);
        textObject.GetComponent<Text>().text = ((int)journey).ToString() + "%";
    }

    public void DeployEngine(){
        engineDeployed = true;
    }

    public void Boost(float value){
        if(blockade)
            return;
        journey += value;
    }

    public int getJourney(){
        return (int)journey;
    }

    public void Blockade(){
        blockade = true;
    }

    public void PassBlockade(){
        blockade = false;
    }

    public void StartStopEngine(){
        engineStopped = !engineStopped;
        engineObject.GetComponent<Thruster>().setSprite(!engineStopped);
    }
}
