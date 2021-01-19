using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGain : MonoBehaviour
{
    [SerializeField]
    private float energyGainValue;

    public void GainEnergy(){
        GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(energyGainValue);
    }
}
