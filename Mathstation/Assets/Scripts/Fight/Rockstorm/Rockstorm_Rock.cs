using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Rock : Rockstorm_Superclass
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private GameObject stone;
    private int clicks = 0;
    [SerializeField]
    private int amt_stones_generated;
    [SerializeField]
    private GameObject nextPhaseObject;
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

    public override void Destroy(){
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        GameObject next_phase = GameObject.Instantiate(nextPhaseObject,Vector3.zero,Quaternion.identity);
        for(int i = 0; i < amt_stones_generated * 2 ; i++)
            GameObject.Instantiate(stone, next_phase.transform);
        GameObject.Destroy(gameObject);
    }

    public new void RecieveMathDamage(){
        Destroy();
    }
}
