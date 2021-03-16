using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Carry>().IsCarrying())
            return;
        other.GetComponent<Carry>().SetCarrying(Carry.Carriables.Moon);
        gameObject.SetActive(false);
    }
}
