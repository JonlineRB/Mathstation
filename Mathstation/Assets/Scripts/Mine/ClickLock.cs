using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script prevents click interactions if locked
public class ClickLock : MonoBehaviour
{
    [SerializeField]
    private bool clickLock = false;

    public bool isLocked(){
        return clickLock;
    }

    public void Lock(){
        clickLock = true;
    }

    public void Unlock(){
        clickLock = false;
    }
}
