using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class that handles the fuel bar GUI element
public class FuelBar : MonoBehaviour
{
    private GameObject player; //Player reference

    void Start(){
        player = GameObject.Find("Player"); //Set the player reference
    }

    // Update is called once per frame
    void Update()
    {   
        //Scale the fuel bar according to the amount of fuel remaining
        transform.localScale = new Vector3(player.GetComponent<Fuel>().GetFuel() / 100f, 1f,1f);
    }
}
