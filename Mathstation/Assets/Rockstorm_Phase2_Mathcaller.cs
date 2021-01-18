using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase2_Mathcaller : Rockstorm_Mathcaller_Super
{
    public override void MathSuccess(){
        gameObject.GetComponent<Rockstorm_Phase2>().RecieveMathDamage();
    }
}
