using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarius_Orb_Spawn : MonoBehaviour
{
    [SerializeField]
    private int amt_of_orbs;
    [SerializeField]
    private float radius;
    [SerializeField]
    private GameObject negOrb;
    [SerializeField]
    private GameObject posOrb;
    public void spawnOrbs(){
        float slice = 360 / amt_of_orbs;
        for(int i = 0; i < amt_of_orbs; i++){
            if(i%2==1)
                GameObject.Instantiate(posOrb, new Vector3( Mathf.Sin(slice*i * Mathf.PI / 180), Mathf.Cos(slice*i * Mathf.PI / 180),0) * radius, Quaternion.identity,transform);
            else
                GameObject.Instantiate(negOrb, new Vector3( Mathf.Sin(slice*i * Mathf.PI / 180), Mathf.Cos(slice*i * Mathf.PI / 180),0) * radius, Quaternion.identity,transform);
        }
    }

    public void Reset(){
        foreach(Transform child in transform)
            child.gameObject.SetActive(true);
    }
}
