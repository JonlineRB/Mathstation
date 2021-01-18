using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase1_MathCaller : Rockstorm_Mathcaller_Super
{   
    public override void MathSuccess(){
        gameObject.GetComponent<Rockstorm_Rock>().RecieveMathDamage();
    }
}
