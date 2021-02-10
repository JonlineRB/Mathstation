using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField]
    private GameObject engine;
    [SerializeField]
    private float boostValue;

    void OnMouseDown(){
        engine.GetComponent<Engine>().Boost(boostValue);
    }
}
