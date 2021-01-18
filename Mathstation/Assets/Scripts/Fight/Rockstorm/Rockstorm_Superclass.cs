using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rockstorm_Superclass : MonoBehaviour
{

    protected GameObject fightGame;
    protected int amt_stones_generated = 6;
    [SerializeField]
    protected GameObject stone;
    [SerializeField]
    protected GameObject nextPhaseObject;
    // Start is called before the first frame update
    protected void Start()
    {
        fightGame = GameObject.Find("FightGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Damage();
    }

    public abstract void Damage();

    public void Destroy(){
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        GameObject next_phase;
        if(nextPhaseObject){
            next_phase = GameObject.Instantiate(nextPhaseObject,Vector3.zero,Quaternion.identity);
            for(int i = 0; i < amt_stones_generated * 2 ; i++)
                GameObject.Instantiate(stone, next_phase.transform);
        }
        GameObject.Destroy(gameObject);
    }

    public void RecieveMathDamage(){
        Destroy();
    }

    protected bool CheckConsumeEnergy(){
        if(fightGame.GetComponent<FightMaster>().consumeEnergyCharge()){
            fightGame.GetComponent<FightMaster>().setPauseCharging();
            gameObject.GetComponent<MathCaller>().CallMathEditor();
            GetComponent<CircleCollider2D>().enabled = false;
            return true;
        }
        return false;
    }
}
