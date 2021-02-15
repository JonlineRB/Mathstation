using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject drill;
    [SerializeField]
    private GameObject engine;
    [SerializeField]
    private GameObject radar;
    [SerializeField]
    private GameObject cannon;
    [SerializeField]
    private GameObject shield;

    public void ActivateDrill(){
        drill.SetActive(true);
    }

    public void ActivateEngine(){
        engine.SetActive(true);
    }

    public void ActivateRadar(){
        radar.SetActive(true);
    }

    public void ActivateCannon(){
        cannon.SetActive(true);
    }

    public void ActivateShield(){
        shield.SetActive(true);
    }
}
