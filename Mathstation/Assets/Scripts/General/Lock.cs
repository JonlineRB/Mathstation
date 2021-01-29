using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private bool locked = true;

    public bool isLocked(){
        return locked;
    }

    public void setLock(bool value){
        locked = value;
    }
}
