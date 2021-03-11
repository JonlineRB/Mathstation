using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLock : MonoBehaviour
{
    private bool moveLock = false;

    public bool isMoveLock(){
        return moveLock;
    }

    public void setMoveLock(bool value){
        moveLock = value;
    }
}
