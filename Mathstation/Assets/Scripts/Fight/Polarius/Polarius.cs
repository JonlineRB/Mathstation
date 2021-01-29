using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarius : MonoBehaviour
{
    [SerializeField]
    private bool isPositive = true;

    public bool orbShot(bool orbValue){
        bool result = (orbValue != isPositive);
        Debug.Log("Orb shot: " + result);
        return result;
    }
}
