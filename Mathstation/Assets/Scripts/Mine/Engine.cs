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

    void Update(){
        if(!engineDeployed)
            return;
        journey += rate * Time.deltaTime;
        //check for events here
        // gameObject.GetComponent<Obstacles>().;
        journey = Mathf.Clamp(journey, 0f, 100f);
        textObject.GetComponent<Text>().text = ((int)journey).ToString() + "%";
    }

    public void DeployEngine(){
        engineDeployed = true;
    }

    public void Boost(float value){
        journey += value;
    }
}
