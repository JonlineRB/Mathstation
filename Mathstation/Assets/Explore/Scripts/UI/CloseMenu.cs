using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handles menu closing in the explore game
public class CloseMenu : MonoBehaviour
{
    //When closing a menu -
    public void UncallMenu(){
        //Resume normal time flow
        gameObject.GetComponent<TimeControl>().ResumeTime();
        //Set player reference
        GameObject player = GameObject.Find("Player");
        //Decrement the player's movement lock
        player.GetComponent<MoveLock>().DecrementMoveLock();
        //Disable the player's marker, to which the ship navigates
        GameObject.Find("TargetMarker").SetActive(false);
        //Disable fuel consumption. It will be set to active upon the player's next movement
        player.GetComponent<Fuel>().SetConsuming(false);
        //Disable this menu object
        gameObject.SetActive(false);
    }
}
