using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Carriable
{
    protected override Carry.Carriables CarryObject()
    {
        return Carry.Carriables.Moon;
    }
}
