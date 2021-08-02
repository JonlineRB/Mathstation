using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass for Phase 1, overrides MathSuccess()
public class Rockstorm_Phase1_MathCaller : Rockstorm_Mathcaller_Super
{   
    public override void MathSuccess(){
        gameObject.GetComponent<Rockstorm_Rock>().RecieveMathDamage();
    }
}
