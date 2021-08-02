using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the UI element of the energy bar
public class EnergyBar : MonoBehaviour
{
    FightMaster master;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("FightGame").GetComponent<FightMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(0.01f * master.energy,1,1);
    }
}
