using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Carriable
{
    //Overrides to carry the Moon object
    protected override Carry.Carriables CarryObject()
    {
        return Carry.Carriables.Moon;
    }
}
