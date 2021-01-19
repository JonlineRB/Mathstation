using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase3_Mathcaller : Rockstorm_Mathcaller_Super
{
    public override void MathSuccess(){
        gameObject.GetComponent<Rockstorm_Phase3>().RecieveMathDamage();
    }
}
