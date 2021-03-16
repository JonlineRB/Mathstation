using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private int objectives = 0;
    [SerializeField] private int targetObjectives;

    [SerializeField] private GameObject goalRing;
    [SerializeField] private Vector3 goalPosition;

    public void Increment(){
        if(++objectives >= targetObjectives){
            GameObject.Instantiate(goalRing, goalPosition, Quaternion.identity);
        }
    }
}
