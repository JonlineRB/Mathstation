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

    public void ActivateDrill(){
        drill.SetActive(true);
    }

    public void ActivateEngine(){
        engine.SetActive(true);
    }

    public void ActivateRadar(){
        radar.SetActive(true);
    }
}
