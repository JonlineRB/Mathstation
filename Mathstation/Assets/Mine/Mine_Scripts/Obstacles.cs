﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private MineGameEvent.EventType[] events;
    [SerializeField]
    private int[] occourences;

    //gadget references
    [SerializeField]
    private GameObject cannon;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject Blockade;

    //other references
    [SerializeField]
    private GameObject pirateShipSpawner;
    [SerializeField]
    private GameObject rockShowerSpawner;

    private  List<(MineGameEvent.EventType, int)> combined = new List<(MineGameEvent.EventType, int)>();

    void Start(){
        System.Array.Sort(occourences);
        for(int i = 0; i < occourences.Length && i < events.Length; i++){
            combined.Add((events[i], occourences[i]));
        }
    }

    public void CheckEvent(int value){
        if(combined.Count==0)
            return;
        if(value>= combined[0].Item2){
            //triger event
            Debug.Log("Event triggered: " + combined[0].Item1);
            switch (combined[0].Item1){
            case MineGameEvent.EventType.Blockade:
                BlockadeEvent();
                break;
            case MineGameEvent.EventType.Pirates:
                PirateEvent();
                break;
            case MineGameEvent.EventType.Shower:
                ShowerEvent();
                break;
            }
            combined.RemoveAt(0);
        }
    }

    private void BlockadeEvent(){
        Blockade.SetActive(true);
        //check if there is cannos
        if(cannon.activeSelf){
        }
        else{
            gameObject.GetComponent<Penalties>().Add(MineGameEvent.EventType.Blockade);
            GameObject.Find("MineGame").GetComponent<Engine>().Blockade();
        }
    }

    private void PirateEvent(){
        //do the visual part
        pirateShipSpawner.SetActive(true);
        
        //check if there is cannos
        bool cannonActive = cannon.activeSelf;
        bool shieldActive = shield.activeSelf;
        if(cannonActive && shieldActive){
            //visual FX here
            cannon.GetComponent<SpriteSwap>().InitSwap();
            shield.GetComponent<EnableTmpSprite>().InitExternalSprite();
            Debug.Log("Pirates defeated!");
        }
        else
            gameObject.GetComponent<Penalties>().Add(MineGameEvent.EventType.Pirates);
    }

    private void ShowerEvent(){
        rockShowerSpawner.SetActive(true);

        //check if shields are active
        bool shieldActive = shield.activeSelf;
        if(shieldActive)
            shield.GetComponent<EnableTmpSprite>().InitExternalSprite();
        else
            gameObject.GetComponent<Penalties>().Add(MineGameEvent.EventType.Shower);

    }


    public List<(MineGameEvent.EventType, int)> getEvents(){
        return combined;
    }
}
