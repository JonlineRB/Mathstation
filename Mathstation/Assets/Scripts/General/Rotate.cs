using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotationRate;
    // Update is called once per frame
    void Update()
    {
        //rotate
        transform.Rotate(new Vector3(0,0,rotationRate));
    }
}
