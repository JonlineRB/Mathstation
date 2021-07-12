using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : Carriable
{
    //Overrides to carry the Ice Cube object
    protected override Carry.Carriables CarryObject()
    {
        return Carry.Carriables.IceCube;
    }
}
