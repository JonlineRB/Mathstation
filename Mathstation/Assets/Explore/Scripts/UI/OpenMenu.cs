using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handles menu openning in the explore game
public class OpenMenu : MonoBehaviour
{
    public void CallMenu(){
        gameObject.SetActive(true); //Activates the menu element
        gameObject.GetComponent<TimeControl>().StopTime(); //Stops time
        GameObject.Find("Player").GetComponent<MoveLock>().IncrementMoveLock(); //Increments the lock on player movement
    }
}
