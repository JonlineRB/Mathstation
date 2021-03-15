using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] private GameObject carriedMoon;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Carry>().IsCarrying())
            return;
        other.GetComponent<Carry>().SetCarrying(Carry.Carriables.Moon);
        GameObject carriedInstance = GameObject.Instantiate(carriedMoon, other.transform.position, Quaternion.identity);
        carriedInstance.GetComponent<FollowPosition>().SetFollowing(other.gameObject);
        //scale
        gameObject.SetActive(false);
    }
}
