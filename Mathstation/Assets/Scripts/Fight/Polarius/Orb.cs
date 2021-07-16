using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private bool isPositive; // Defines whether the orb is positive or negative
    private int nrgDrain = -5; // Energy value drained as penalty

    // 
    void OnMouseDown(){
        bool result = GameObject.Find("Polarius").GetComponent<Polarius>().orbShot(isPositive);
        if(result)
            gameObject.SetActive(false);
        else{
            GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(nrgDrain);
            StartCoroutine(gameObject.GetComponent<FlashColor>().Flash());
        }
            
    }
    public void Swap(){
        isPositive = !isPositive;
    }
}
