using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Superclass for objects that the player can carry in the explore game
public class Carriable : MonoBehaviour
{
    //The player carries an object if they enter the object's collider and are not carring currently
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Carry>().IsCarrying())
            return;
        other.GetComponent<Carry>().SetCarrying(CarryObject());
        gameObject.SetActive(false);
    }

    //Fetches the apropriate object to carry
    //Override in subclass to set specific objects to carry
    protected virtual Carry.Carriables CarryObject(){
        return Carry.Carriables.None;
    }
}
