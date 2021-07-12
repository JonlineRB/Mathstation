using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUpRing : Ring
{
    //Upgrades the player's fuel consumption rate
    protected override void ApplyRingEffect()
    {
        player.GetComponent<Fuel>().RateUp();
    }
}
