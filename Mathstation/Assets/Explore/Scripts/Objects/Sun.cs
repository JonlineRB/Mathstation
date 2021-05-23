using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Reciever
{
    [SerializeField] private Sprite coolSprite;
    [SerializeField] private GameObject particleFX;
    protected override void DefaultBehaviour(Collider2D other)
    {
        other.GetComponent<Reset>().InitReset();
    }

    protected override Carry.Carriables Expected(){
        return Carry.Carriables.IceCube;
    }

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
