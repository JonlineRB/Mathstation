using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private GameObject player;

    void Start(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        transform.localScale = new Vector3(player.GetComponent<Fuel>().GetFuel() / 100f, 1f,1f);
    }
}
