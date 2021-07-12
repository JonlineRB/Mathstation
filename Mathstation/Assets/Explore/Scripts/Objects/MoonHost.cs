using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Planet reciever object, expects the moon object
public class MoonHost : Reciever
{
    //Reference of the prefab to be instantiated during resolve
    [SerializeField] private GameObject carriedMoon;
    //Sprite reference, to be displayed during resolve
    [SerializeField] private Sprite happy;
    

    //Expected object is Moon
    protected override Carry.Carriables Expected(){
        return Carry.Carriables.Moon;
    }

    //Overrides resolve to instantiate a moon and change sprite
    protected override void Resolve(Collider2D player)
    {
        base.Resolve(player);
        GameObject.Instantiate(carriedMoon, transform.position, Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().sprite = happy;
    }
}
