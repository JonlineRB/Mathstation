using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonHost : MonoBehaviour
{
    [SerializeField] private GameObject carriedMoon;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Carry>().IsCarrying() && other.GetComponent<Carry>().GetCarrying()==Carry.Carriables.Moon){
            other.GetComponent<Carry>().SetCarrying(Carry.Carriables.None);
            GameObject.Instantiate(carriedMoon, transform.position, Quaternion.identity);
            //change the sprite from a sad planet to a happy one
            //increment objectives
            other.GetComponent<Objective>().Increment();
        }
    }
}
