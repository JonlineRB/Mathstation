﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField]
    private GameObject engine;
    [SerializeField]
    private float boostValue;

    void OnMouseDown(){
        if(GameObject.Find("MineGame").GetComponent<ClickLock>().isLocked())
            return;
        engine.GetComponent<Engine>().Boost(boostValue);
    }
}
