using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Rock : MonoBehaviour
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
    private GameObject fightGame;
    // Start is called before the first frame update
    void Start()
    {
        fightGame = GameObject.Find("FightGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(){
        clicks++;
        if(clicks<sprites.Length){
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[clicks];
            for(int i = 0; i < amt_stones_generated ; i++)
                GameObject.Instantiate(stone, transform);
        }
        else{
            if(fightGame.GetComponent<FightMaster>().consumeEnergyCharge()){
                fightGame.GetComponent<FightMaster>().setPauseCharging();
                gameObject.GetComponent<MathCaller>().CallMathEditor();
                GetComponent<CircleCollider2D>().enabled = false;
            }
                
        }
    }

    void Destroy(){
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        GameObject next_phase = GameObject.Instantiate(nextPhaseObject,Vector3.zero,Quaternion.identity);
        for(int i = 0; i < amt_stones_generated * 2 ; i++)
            GameObject.Instantiate(stone, next_phase.transform);
        GameObject.Destroy(gameObject);
    }

    public void RecieveMathDamage(){
        Destroy();
    }

    void OnMouseDown(){
        Damage();
    }
}
