using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sun receiver object
public class Sun : Reciever
{
    //Sprite reference, to be swapped on resolve
    [SerializeField] private Sprite coolSprite;
    //Reference for particle system object
    [SerializeField] private GameObject particleFX;

    //Default behaviour resets the player
    protected override void DefaultBehaviour(Collider2D other)
    {
        other.GetComponent<Reset>().InitReset();
    }

    //Expected object is Ice Cube
    protected override Carry.Carriables Expected(){
        return Carry.Carriables.IceCube;
    }

    //Resolve disables the particle system, changes the sprite, and disables this object's collider
    protected override void Resolve(Collider2D other)
    {
        base.Resolve(other);
        //switch the sun's sprite to the cool version
        gameObject.GetComponent<SpriteRenderer>().sprite=coolSprite;
        GameObject.Destroy(particleFX);
        //disable collider
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
