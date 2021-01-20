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
    [SerializeField]
    protected float energyGainValue;
    [SerializeField]
    protected GameObject dialogue;
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
        if(gameObject.GetComponent<Lock>().isLocked())
            return;
        gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
        fightGame.GetComponent<FightMaster>().energyGain(energyGainValue);
        Damage();
    }

    public abstract void Damage();

    public virtual void Destroy(){
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        GameObject next_phase;
        if(nextPhaseObject){
            next_phase = GameObject.Instantiate(nextPhaseObject,Vector3.zero,Quaternion.identity);
            gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
            gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
            fightGame.GetComponent<FightMaster>().setOpponent(next_phase);
        }
        if(dialogue)
            GameObject.Instantiate(dialogue, fightGame.transform);
        GameObject.Destroy(gameObject);
    }

    public void RecieveMathDamage(){
        Destroy();
    }

    protected bool CheckConsumeEnergy(){
        if(fightGame.GetComponent<FightMaster>().consumeEnergyCharge()){
            fightGame.GetComponent<FightMaster>().setPauseCharging();
            gameObject.GetComponent<MathCaller>().CallMathEditor();
            gameObject.GetComponent<Lock>().setLock(true);
            return true;
        }
        return false;
    }
}
