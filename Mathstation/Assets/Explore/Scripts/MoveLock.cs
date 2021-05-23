using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLock : MonoBehaviour
{
    private int moveLock = 0;

    public bool IsMoveLock(){
        return moveLock > 0;
    }

    // public void setMoveLock(bool value){
    //     moveLock = value;
    // }

    public void IncrementMoveLock(){
        moveLock++;
    }

    public void DecrementMoveLock(){
        moveLock = Mathf.Max(--moveLock,0);
    }
}
