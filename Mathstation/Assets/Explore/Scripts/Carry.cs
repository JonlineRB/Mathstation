﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{

    public enum Carriables {None, Moon, Cork, IceCube}
    private GameObject carryReference;
    [SerializeField] private GameObject carriedMoon;
    [SerializeField] private GameObject carriedCork;
    [SerializeField] private GameObject carriedIceCube;
    private Carriables carrying;
    // Start is called before the first frame update
    void Start()
    {
        carrying = Carriables.None;
    }

    public void SetCarrying(Carriables value){
        carrying = value;
        switch (carrying){
            case Carriables.None:
                GameObject.Destroy(carryReference);    
                break;
            case Carriables.Moon:
                GameObject moon = GameObject.Instantiate(carriedMoon, transform.position, Quaternion.identity);
                moon.GetComponent<FollowPosition>().SetFollowing(gameObject);
                carryReference = moon;
                break;
            case Carriables.Cork:
                GameObject cork = GameObject.Instantiate(carriedCork, transform.position, Quaternion.identity);
                cork.GetComponent<FollowPosition>().SetFollowing(gameObject);
                carryReference = cork;
                break;
            case Carriables.IceCube:
                GameObject iceCube = GameObject.Instantiate(carriedIceCube, transform.position, Quaternion.identity);
                iceCube.GetComponent<FollowPosition>().SetFollowing(gameObject);
                carryReference = iceCube;
                break;
        }
        if(carrying == Carriables.None)
            GameObject.Destroy(carryReference);
    }

    public Carriables GetCarrying(){
        return carrying;
    }

    public bool IsCarrying(){
        return carrying!=Carriables.None;
    }
}