using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpRing : Ring
{
    protected override void ApplyRingEffect(){
        player.GetComponent<ExplorePlayerControls>().SpeedUp();
    }    
}
