using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cork : Carriable
{
    //Overrides to carry the Cork object
    protected override Carry.Carriables CarryObject()
    {
        return Carry.Carriables.Cork;
    }
}
