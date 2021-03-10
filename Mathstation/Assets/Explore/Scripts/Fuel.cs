using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private bool isConsuming = false;
    [SerializeField] private float consumptionRate;
    [SerializeField] private int capacity;
    private float fuel;

    void Start(){
        fuel = (float)capacity;
    }

    // Update is called once per frame
    void Update()
    {
        if(isConsuming){
            fuel -= consumptionRate * Time.deltaTime;
        }
        Debug.Log(fuel);

        if(fuel<=0){
            gameObject.GetComponent<Reset>().InitReset();
        }
    }

    public void SetConsuming(bool value){
        isConsuming = value;
    }

    public void ResetFuel(){
        fuel = capacity;
    }
}
