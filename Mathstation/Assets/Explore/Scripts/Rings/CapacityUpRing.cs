using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityUpRing : Ring
{
    //Increases the player's fuel capcaity
    protected override void ApplyRingEffect(){
        player.GetComponent<Fuel>().CapacityUp();
    }
}
