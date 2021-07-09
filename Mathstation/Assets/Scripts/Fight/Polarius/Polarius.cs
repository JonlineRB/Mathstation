﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Polarius : MonoBehaviour
{
    [SerializeField]
    private bool isPositive = true;
    [SerializeField]
    private float flashDuration;
    private bool isVulnerable = false;
    [SerializeField]
    private Color shielded;
    [SerializeField]
    private Color vulnerable;
    [SerializeField]
    private int nrgGainValue;
    [SerializeField]
    private int shield;
    [SerializeField]
    private int maxShield;
    [SerializeField]
    private float vuln_time;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private Sprite phase2;
    [SerializeField]
    private Sprite phase3Plus;
    [SerializeField]
    private Sprite phase3Minus;
    [SerializeField]
    private GameObject explosion;
    private bool isAttacking = false;
    [SerializeField]
    private float attack_interval;
    private bool doingMath = false;

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        //delay here
        //spawn orbs
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().spawnOrbs();
        StartCoroutine("AutoAttack");
        BecomeInvulnerable();
    }

    public bool orbShot(bool orbValue){
        bool result = (orbValue != isPositive);
        if(result){
            DecrementShield();
        }
            
        else
            StartCoroutine("Attack");
        return result;
    }

    private IEnumerator FlashRed(){
        Color og = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color=Color.red;
        yield return new WaitForSeconds(flashDuration);
        gameObject.GetComponent<SpriteRenderer>().color=og;
    }

    void OnMouseDown(){
        if(isAttacking){
            isAttacking = false;
            StopCoroutine("Attack");
            gameObject.GetComponent<SpriteRenderer>().color = shielded;
            gameObject.GetComponent<MouseOverCursorChange>().Lock();
            gameObject.GetComponent<MouseOverCursorChange>().ApplyDefaultCursor();
        }
        if(!isVulnerable)
            return;
        bool consumed = GameObject.Find("FightGame").GetComponent<FightMaster>().consumeEnergyCharge();
        if(consumed){
            //disable stuff
            doingMath = true;
            GameObject.Find("FightGame").GetComponent<FightMaster>().setPauseCharging();
            //call math editor
            gameObject.GetComponent<Polarius_Mathcaller>().CallMathEditor();
            gameObject.GetComponent<Collider2D>().enabled=false;
        }
        else
            GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(nrgGainValue);
    }

    private void DecrementShield(){
        if(--shield<=0){
            // isVulnerable = true;
            BecomeVulnerable();
            gameObject.GetComponent<SpriteRenderer>().color = vulnerable;
            //begin coroutine to reset
            StartCoroutine(ResetShield());
        }
        else
            StartCoroutine(FlashRed());
    }

    private IEnumerator ResetShield(){
        StopCoroutine("Attack");
        StopCoroutine("AutoAttack");
        yield return new WaitForSeconds(vuln_time);
        if(life==1){
            isPositive = !isPositive;
            switch(isPositive){
                case true:
                    gameObject.GetComponent<SpriteRenderer>().sprite = phase3Plus;
                    break;
                case false:
                    gameObject.GetComponent<SpriteRenderer>().sprite = phase3Minus;
                    break;
            }
        }
        // isVulnerable = false;
        BecomeInvulnerable();
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        shield = maxShield;
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().Reset();
        StartCoroutine("AutoAttack");
    }


    public void MathSuccess(){
        GameObject.Find("FightGame").GetComponent<FightMaster>().releasePauseCharging();
        gameObject.GetComponent<Collider2D>().enabled = true;
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().NextPhase();

       switch (--life) {
           case 2:
                //shift to phase 2
                gameObject.GetComponent<SpriteRenderer>().sprite = phase2;
                isPositive = false;
                break;
           case 1:
                //shift to phase 3
                gameObject.GetComponent<SpriteRenderer>().sprite = phase3Plus;
                isPositive = true;
                break;
           case 0: 
                GameObject.Find("FightGame").GetComponent<FightMaster>().winGame();
                GameObject.Destroy(gameObject);
                break;
       }
       maxShield += 2;
       shield = maxShield;
       doingMath = false;
    }

    private IEnumerator Attack(){
        isAttacking = true;
        gameObject.GetComponent<MouseOverCursorChange>().Unlock();
        for(int i = 0; i < 7; i ++){
            gameObject.GetComponent<SpriteRenderer>().color=Color.red;
            yield return new WaitForSeconds(0.075f);
            gameObject.GetComponent<SpriteRenderer>().color=shielded;
            yield return new WaitForSeconds(0.075f);
        }

        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);

        GameObject.Find("FightGame").GetComponent<FightMaster>().DecrementLife();
        
        isAttacking = false;
        gameObject.GetComponent<MouseOverCursorChange>().Lock();
    }

    private IEnumerator AutoAttack(){
        while(true){
        yield return new WaitForSeconds(attack_interval);
        if(!isAttacking && !doingMath)
            StartCoroutine("Attack");
        }
    }

    private void BecomeVulnerable(){
        isVulnerable = true;
        gameObject.GetComponent<MouseOverCursorChange>().Unlock();
    }

    private void BecomeInvulnerable(){
        isVulnerable = false;
        gameObject.GetComponent<MouseOverCursorChange>().Lock();
        gameObject.GetComponent<MouseOverCursorChange>().ApplyDefaultCursor();

    }


}
