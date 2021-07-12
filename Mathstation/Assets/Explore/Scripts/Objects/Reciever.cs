using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Superclass for reciever objects in the explore game
public class Reciever : MonoBehaviour
{
    //A reciever accepts a delivered object, carried by the player, if it is the object it was expecting.
    //Initiated when the player enters the receiver's collider
    public void OnTriggerEnter2D(Collider2D player){
        if(player.GetComponent<Carry>().IsCarrying() && player.GetComponent<Carry>().GetCarrying() == Expected()){
            //Resolve reciever (deliverd successfuly)
            Resolve(player);
            //Increment the objective counter of the player
            player.GetComponent<Objective>().Increment();
        }
        else{
            //If the conditions are not met, act as normal
            DefaultBehaviour(player);
        }
    }

    //Subclasses override this with their specific expected carriable objects
    protected virtual Carry.Carriables Expected(){
        return Carry.Carriables.None;
    }

    //Method executes when the right carriable object is delivered
    protected virtual void Resolve(Collider2D player){
        player.GetComponent<Carry>().SetCarrying(Carry.Carriables.None);
    }

    //Method executes when not carrying, or when carrying the wrong item
    protected virtual void DefaultBehaviour(Collider2D other){}
}
