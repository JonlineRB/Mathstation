using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityUpRing : Ring
{
    protected override void ApplyRingEffect(){
        player.GetComponent<Fuel>().CapacityUp();
    }
}
