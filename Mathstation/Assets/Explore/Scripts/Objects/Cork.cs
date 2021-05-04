using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cork : Carriable
{
    // Start is called before the first frame update
    protected override Carry.Carriables CarryObject()
    {
        return Carry.Carriables.Cork;
    }
}
