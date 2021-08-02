using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rockstorm 1st phase script
public class Rockstorm_Rock : Rockstorm_Superclass
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private int clicks = 0;

    public override void Damage(){
        clicks++;
        // change the sprite based on the amount of clicks
        if(clicks<sprites.Length){
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[clicks];
        }
        else
            CheckConsumeEnergy();
    }

    public new void RecieveMathDamage(){
        Destroy();
    }
}
