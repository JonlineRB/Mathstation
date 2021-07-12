using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handles movement marker of the player, to which the ship moves
public class Explore_MoveMarker : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            other.gameObject.GetComponent<Fuel>().SetConsuming(false);
            gameObject.SetActive(false);
        }
    }
}
