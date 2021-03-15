using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUpRing : Ring
{
    protected override void ApplyRingEffect()
    {
        player.GetComponent<Fuel>().RateUp();
    }
}
