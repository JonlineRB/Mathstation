using System.Collections;
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

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        //delay here
        //spawn orbs
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().spawnOrbs();
        StartCoroutine("AutoAttack");
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
        }
        if(!isVulnerable)
            return;
        bool consumed = GameObject.Find("FightGame").GetComponent<FightMaster>().consumeEnergyCharge();
        if(consumed){
            //disable stuff
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
            isVulnerable = true;
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
        isVulnerable = false;
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        shield = 3;
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().Reset();
        StartCoroutine("AutoAttack");
    }


    public void MathSuccess(){
        GameObject.Find("FightGame").GetComponent<FightMaster>().releasePauseCharging();
        gameObject.GetComponent<Collider2D>().enabled = true;

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
                SceneManager.LoadScene(3);
                break;
       }
    }

    private IEnumerator Attack(){
        isAttacking = true;
        for(int i = 0; i < 7; i ++){
            gameObject.GetComponent<SpriteRenderer>().color=Color.red;
            yield return new WaitForSeconds(0.075f);
            gameObject.GetComponent<SpriteRenderer>().color=shielded;
            yield return new WaitForSeconds(0.075f);
        }

        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);

        GameObject.Find("FightGame").GetComponent<FightMaster>().DecrementLife();
        
        isAttacking = false;
    }

    private IEnumerator AutoAttack(){
        while(true){
        yield return new WaitForSeconds(attack_interval);
        if(!isAttacking)
            StartCoroutine("Attack");
        }
    }


}
