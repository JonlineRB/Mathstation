using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ClickLockedObject
{
    [SerializeField]
    private GameObject engine;
    [SerializeField]
    private float boostValue;

    void OnMouseDown(){
        if(IsLocked())
            return;
        engine.GetComponent<Engine>().Boost(boostValue);
    }
}
