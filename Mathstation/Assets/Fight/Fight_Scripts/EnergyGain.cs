using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script handles increases in the player's energy value
public class EnergyGain : MonoBehaviour
{
    [SerializeField]
    private float energyGainValue;

    public void GainEnergy(){
        GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(energyGainValue);
    }
}
