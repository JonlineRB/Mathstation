using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : Reciever
{
    //sprite to change to in this receiver's resolve
    [SerializeField] private Sprite corked;

    protected override Carry.Carriables Expected(){
        return Carry.Carriables.Cork;
    }

    protected override void Resolve(Collider2D other){
        base.Resolve(other);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = corked;
        //disables the particle system
        transform.GetChild(0).gameObject.SetActive(false);
    }

    protected override void DefaultBehaviour(Collider2D other){
        other.GetComponent<Reset>().InitReset();
    }
    

    
}
