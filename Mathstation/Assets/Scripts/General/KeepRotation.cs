using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script keeps an object in Quaternion.identity rotation on Update()
public class KeepRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
