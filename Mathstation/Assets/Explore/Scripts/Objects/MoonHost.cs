using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonHost : Reciever
{
    [SerializeField] private GameObject carriedMoon;
    

    protected override Carry.Carriables Expected(){
        return Carry.Carriables.Moon;
    }

    protected override void Resolve(Collider2D other)
    {
        base.Resolve(other);
        GameObject.Instantiate(carriedMoon, transform.position, Quaternion.identity);
        
    }
}
