using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarius_Orb_Spawn : MonoBehaviour
{
    [SerializeField]
    private int amt_of_orbs;
    [SerializeField]
    private GameObject orb_spawn;
    public void spawnOrbs(){
        //spawb the prefab that has the orbs as children
        GameObject.Instantiate(orb_spawn);
    }
}
