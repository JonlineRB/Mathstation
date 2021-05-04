using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Carry>().IsCarrying())
            return;
        other.GetComponent<Carry>().SetCarrying(CarryObject());
        gameObject.SetActive(false);
    }

    //fetches the apropriate object to carry
    //override in subclass
    protected virtual Carry.Carriables CarryObject(){
        return Carry.Carriables.None;
    }
}
