using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Vortex receiver object
public class Vortex : Reciever
{
    //Sprite to change to in this receiver's resolve
    [SerializeField] private Sprite corked;

    //Expected object is the Cork
    protected override Carry.Carriables Expected(){
        return Carry.Carriables.Cork;
    }

    //Resolve changes the sprite, disables collider, and disables the particle system
    protected override void Resolve(Collider2D other){
        base.Resolve(other);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = corked;
        //disables the particle system
        transform.GetChild(0).gameObject.SetActive(false);
    }

    //Default behaviour resets the player
    protected override void DefaultBehaviour(Collider2D other){
        other.GetComponent<Reset>().InitReset();
    }
    

    
}
