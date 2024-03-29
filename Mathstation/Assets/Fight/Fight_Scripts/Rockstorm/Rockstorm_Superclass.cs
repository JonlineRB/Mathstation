﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Superclass for Rockstorm boss fight, inherited by different phases of the boss
public abstract class Rockstorm_Superclass : MonoBehaviour
{

    protected GameObject fightGame; // Reference to the fight game object
    protected int amt_stones_generated = 6; // Amount of stones generated by an explosion effect on the boss (not an attack)
    [SerializeField]
    protected GameObject stone; // Prefab reference of a stone sprite
    [SerializeField]
    protected GameObject nextPhaseObject; // Reference to the next phase prefab
    [SerializeField]
    protected float energyGainValue; // The amount of energy a player gains by shooting this object
    [SerializeField]
    protected GameObject dialogue;
    // Start is called before the first frame update
    protected void Start()
    {
        fightGame = GameObject.Find("FightGame");
    }

    void OnMouseDown(){
        // If a lock is in place, return
        if(gameObject.GetComponent<Lock>().isLocked())
            return;
        // Shooting makes an explosion effect, player gains energy, calls Damage().
        gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
        fightGame.GetComponent<FightMaster>().energyGain(energyGainValue);
        Damage();
    }

    // Abstract method to be overrided by subclasses. Invoked when shot by the player
    public abstract void Damage();

    // Destruction sequence.
    public virtual void Destroy(){
        // Player can resume charging
        fightGame.GetComponent<FightMaster>().releasePauseCharging();

        //Optional, invoked if the next phase reference is set
        GameObject next_phase;
        if(nextPhaseObject){
            next_phase = GameObject.Instantiate(nextPhaseObject,Vector3.zero,Quaternion.identity);
            gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
            gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
            fightGame.GetComponent<FightMaster>().setOpponent(next_phase);
        }

        // Optional dialogue if the dialogue reference is set
        if(dialogue)
            GameObject.Instantiate(dialogue, fightGame.transform);

        GameObject.Destroy(gameObject);
    }

    // Invoked by mathcaller after solving math
    public void RecieveMathDamage(){
        Destroy();
    }

    // Invoked by a charged shot of the player
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
