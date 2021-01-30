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

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = shielded;
        //delay here
        //spawn orbs
        GameObject.Find("OrbParent").GetComponent<Polarius_Orb_Spawn>().spawnOrbs();
    }

    public bool orbShot(bool orbValue){
        bool result = (orbValue != isPositive);
        Debug.Log("Orb shot: " + result);
        if(result)
            StartCoroutine(FlashRed());
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
}
