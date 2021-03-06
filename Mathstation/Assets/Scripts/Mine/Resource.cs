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
    private bool broken = false;
    private bool fullPopFX = true;


    void Update(){
        if(broken)
            return;
        metals += passiveGainRate * Time.deltaTime;
        metals = Mathf.Clamp(metals, 0, 100);
        textObject.GetComponent<Text>().text = ((int)metals).ToString();
        if(metals >= 100 && fullPopFX){
            fullPopFX = false;
            GameObject.Find("ResourceUI").GetComponent<PopFadeGUI>().initPopFade();
        }
    }
    

    public void Consume(){
        metals = 0;
        fullPopFX = true;
    }

    public void Boost(float value){
        metals += value;
    }

    public void Reduce(){}

    public bool isFullResources(){
        return metals==100;
    }

    public bool IsBroken(){
        return broken;
    }

    public void Break(){
        broken = true;
    }

    public void Repair(){
        broken = false;
    }
}
