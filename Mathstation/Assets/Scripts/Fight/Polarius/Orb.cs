using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField]
    private bool isPositive;
    void OnMouseDown(){
        GameObject.Find("Polarius").GetComponent<Polarius>().orbShot(isPositive);
    }
}
