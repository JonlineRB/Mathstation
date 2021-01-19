using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Rock : Rockstorm_Superclass
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private int clicks = 0;
    void Update()
    {
        
    }

    public override void Damage(){
        clicks++;
        if(clicks<sprites.Length){
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[clicks];
            // gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
        }
        else
            CheckConsumeEnergy();
    }

    public new void RecieveMathDamage(){
        Destroy();
    }
}
