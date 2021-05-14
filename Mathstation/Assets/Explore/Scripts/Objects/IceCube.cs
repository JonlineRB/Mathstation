using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : Carriable
{
    protected override Carry.Carriables CarryObject()
    {
        return Carry.Carriables.IceCube;
    }
}
