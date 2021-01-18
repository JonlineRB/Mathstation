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
            for(int i = 0; i < amt_stones_generated ; i++)
                GameObject.Instantiate(stone, transform);
        }
        else
            CheckConsumeEnergy();
    }

    public new void RecieveMathDamage(){
        Destroy();
    }
}
