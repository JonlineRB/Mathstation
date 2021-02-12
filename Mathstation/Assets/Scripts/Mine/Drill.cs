using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : ClickLockedObject
{
    [SerializeField]
    private float boostValue;

    [SerializeField]
    private GameObject resourceObject;
    // private bool broken = false;
    [SerializeField]
    private float breakTimerFlat;
    [SerializeField]
    private float breakTimerRandom;

    void OnMouseDown(){
        if(IsLocked())
            return;
        if(GameObject.Find("MineGame").GetComponent<Resource>().IsBroken()){
            Debug.Log("Activate drill repair sequence here");
        }
        resourceObject.GetComponent<Resource>().Boost(boostValue);
    }

    private void Break(){
        GameObject.Find("MineGame").GetComponent<Resource>().Break();
    }

    void Start(){
        StartCoroutine("InitBreak");
    }

    IEnumerator InitBreak(){
        yield return new WaitForSeconds(breakTimerFlat);
        yield return new WaitForSeconds(Random.Range(0, breakTimerRandom));
        Break();
    }
}
