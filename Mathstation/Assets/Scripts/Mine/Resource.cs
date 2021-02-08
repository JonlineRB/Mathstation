using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private float metals; //this is the game's resource for construction
    [SerializeField]
    private float passiveGainRate;
    [SerializeField]
    private GameObject textObject;


    void Update(){
        metals = Mathf.Clamp(metals, 0, 100);
        textObject.GetComponent<Text>().text = ((int)metals).ToString();
    }

    void FixedUpdate(){
        metals += passiveGainRate * Time.deltaTime;
    }
    

    public void Consume(){}

    public void Boost(float value){
        metals += value;
    }

    public void Reduce(){}
}
