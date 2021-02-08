using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField]
    private float boostValue;

    [SerializeField]
    private GameObject resourceObject;

    void OnMouseDown(){
        resourceObject.GetComponent<Resource>().Boost(boostValue);
    }
}
