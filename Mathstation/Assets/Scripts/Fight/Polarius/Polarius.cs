using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        //delay here
        //spawn orbs
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().spawnOrbs();
    }

    public bool orbShot(bool orbValue){
        bool result = (orbValue != isPositive);
        Debug.Log("Orb shot: " + result);
        if(result){
            DecrementShield();
        }
            
        else
            GameObject.Find("OrbParent").GetComponent<Rotate>().speedUp(20f);
        return result;
    }

    private IEnumerator FlashRed(){
        Color og = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color=Color.red;
        yield return new WaitForSeconds(flashDuration);
        gameObject.GetComponent<SpriteRenderer>().color=og;
    }

    void OnMouseDown(){
        if(!isVulnerable)
            return;
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
        yield return new WaitForSeconds(vuln_time);
        isVulnerable = false;
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        shield = 3;
    }
}
