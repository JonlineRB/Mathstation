﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase2 : Rockstorm_Superclass
{
    [SerializeField]
    private float interRockInterval;
    [SerializeField]
    protected GameObject rocksToThrow;
    [SerializeField]
    protected float radius;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        StartCoroutine(ThrowRocks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void SpawnRock(){
        int deg = Random.Range(0,360);
        Vector3 position = new Vector3(Mathf.Sin(deg), Mathf.Cos(deg), 0) * radius;
        GameObject.Instantiate(rocksToThrow, position, Quaternion.identity);
    }

    

    IEnumerator ThrowRocks(){
        while(true){
            yield return new WaitForSeconds(interRockInterval);
            //Spawn a damaging rock
            SpawnRock();
        }
    }

    public override void Damage()
    {
        if(CheckConsumeEnergy())
            StopAllCoroutines();
    }
}
