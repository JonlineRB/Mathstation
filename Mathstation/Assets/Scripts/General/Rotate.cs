using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotation script
public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotationRate;
    [SerializeField]
    private float accelaration;
    [SerializeField]
    private float limit;
    // Update is called once per frame
    void Update()
    {
        //rotate
        transform.Rotate(new Vector3(0,0,rotationRate*Time.deltaTime));

        if(accelaration!=0){
            rotationRate+=accelaration*Time.deltaTime;
            rotationRate = Mathf.Clamp(rotationRate, 0, limit);
        }

    }

    public void speedUp(float value){
        rotationRate += value;
    }
}
