using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColideToReset : MonoBehaviour
{
    //Invokes the player's reset when they enter the collider
    public void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player" && gameObject.activeSelf){
            other.gameObject.GetComponent<Reset>().InitReset();
        }
    }
}
