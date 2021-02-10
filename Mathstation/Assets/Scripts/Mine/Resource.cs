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
    [SerializeField]
    private GameObject[] deployButtons;


    void Update(){
        metals += passiveGainRate * Time.deltaTime;
        metals = Mathf.Clamp(metals, 0, 100);
        textObject.GetComponent<Text>().text = ((int)metals).ToString();
    }
    

    public void Consume(){
        metals = 0;
    }

    public void Boost(float value){
        metals += value;
    }

    public void Reduce(){}

    public bool isFullResources(){
        return metals==100;
    }
}
