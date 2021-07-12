using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script keeps track of resolved objectives, and stores the target value for the level.
// Reaching the target resolved objective count will instantiate the goal ring in the specified position.
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
