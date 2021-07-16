using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script handles orb instantiation for Polarius stage of the fight game
public class Polarius_Orb_Spawn : MonoBehaviour
{
    [SerializeField]
    private int amt_of_orbs;
    [SerializeField]
    private float radius;
    [SerializeField]
    private GameObject negOrb; // Reference
    [SerializeField]
    private GameObject posOrb; // Reference

    // Instantiates orbs in a circle with the set radius.
    // Space between orbs is derived from the amount of orbs, see variable slice.
    public void spawnOrbs(){
        float slice = 360 / amt_of_orbs;
        for(int i = 0; i < amt_of_orbs; i++){
            if(i%2==1)
                GameObject.Instantiate(posOrb, new Vector3( Mathf.Sin(slice*i * Mathf.PI / 180), Mathf.Cos(slice*i * Mathf.PI / 180),0) * radius, Quaternion.identity,transform);
            else
                GameObject.Instantiate(negOrb, new Vector3( Mathf.Sin(slice*i * Mathf.PI / 180), Mathf.Cos(slice*i * Mathf.PI / 180),0) * radius, Quaternion.identity,transform);
        }
    }

    // Activates all orb objects

    public void Reset(){
        foreach(Transform child in transform)
            child.gameObject.SetActive(true);
    }

    // Destroys orbs, adds more for the next stage, instantiates them again
    public void NextPhase(){
        //kill all kids! D:
        foreach(Transform child in transform)
            GameObject.Destroy(child.gameObject);
        amt_of_orbs += 4;
        spawnOrbs();
    }
}
