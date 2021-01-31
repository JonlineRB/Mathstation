using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField]
    private bool isPositive;
    private int nrgDrain = -5;
    void OnMouseDown(){
        bool result = GameObject.Find("Polarius").GetComponent<Polarius>().orbShot(isPositive);
        if(result)
            // GameObject.Destroy(gameObject);
            gameObject.SetActive(false);
        else
            GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(nrgDrain);
    }
    public void Swap(){
        isPositive = !isPositive;
    }
}
