using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRing : Ring
{
    [SerializeField] private GameObject report;
    protected override void ApplyRingEffect()
    {
        GameObject.Instantiate(report);
    }

    void Start(){
        GameObject.Find("Main Camera").GetComponent<ShowToCamera>().InitPan(transform.position);
    }
}
