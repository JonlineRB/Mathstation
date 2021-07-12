using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRing : Ring
{
    [SerializeField] private GameObject report; //End of level report reference
    //Instantiates end of level report
    protected override void ApplyRingEffect()
    {
        GameObject.Instantiate(report);
    }

    void Start(){
        //Camera pans to this object when the goal ring is instantiated
        GameObject.Find("Main Camera").GetComponent<ShowToCamera>().InitPan(transform.position);
    }
}
