using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move lock script for the plyaer.
// The lock is free when 0, and locked when above it.
// Increment the lock to lock it.
// This allows for several reasons for locking to be handled at once
// All sources have to decrement in order to realease the player movement
public class MoveLock : MonoBehaviour
{
    private int moveLock = 0;

    public bool IsMoveLock(){
        return moveLock > 0;
    }

    public void IncrementMoveLock(){
        moveLock++;
    }

    public void DecrementMoveLock(){
        moveLock = Mathf.Max(--moveLock,0);
    }
}
