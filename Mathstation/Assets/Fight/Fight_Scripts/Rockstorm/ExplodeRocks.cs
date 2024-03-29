﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the visual effects of exploding rocks
public class ExplodeRocks : MonoBehaviour
{
    [SerializeField]
    private GameObject stone; // prefab reference
    [SerializeField]
    private int amtOfStones; // Amount of stones in the explosion

    public void Explode(Vector3 position){
        for(int i = 0; i <= amtOfStones; i++){
            GameObject.Instantiate(stone, position + new Vector3(0,0,-1), Quaternion.identity);
        }
    }

    public void Explode(Vector3 position, int amt){
        for(int i = 0; i <= amt; i++){
            GameObject.Instantiate(stone, position, Quaternion.identity);
        }
    }
}
