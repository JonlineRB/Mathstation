using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Carry>().IsCarrying() && other.GetComponent<Carry>().GetCarrying() == Expected()){
            Resolve(other);
            other.GetComponent<Objective>().Increment();
        }
        else{
            DefaultBehaviour(other);
        }
    }

    //Subclasses override this with their expected carriable objects
    protected virtual Carry.Carriables Expected(){
        return Carry.Carriables.None;
    }

    //method executes when the right carriable object is delivered
    protected virtual void Resolve(Collider2D other){
        other.GetComponent<Carry>().SetCarrying(Carry.Carriables.None);
    }

    //method executes when not carrying, or when carrying the wrong item
    protected virtual void DefaultBehaviour(Collider2D other){}
}
