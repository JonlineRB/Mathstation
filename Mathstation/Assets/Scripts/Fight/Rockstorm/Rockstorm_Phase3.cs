using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase3 : Rockstorm_Phase2
{
    [SerializeField]
    private GameObject rocksCenter;

    protected override void SpawnRock(){
        int deg = Random.Range(0,360);
        Vector3 position = new Vector3(Mathf.Sin(deg), Mathf.Cos(deg), 0) * radius;
        GameObject rock = GameObject.Instantiate(rocksToThrow, position, Quaternion.identity, rocksCenter.transform);
        rocks.Add(rock);
    }

    public override void Destroy(){
        //initiate crumbling animation, call win at the end
        fightGame.GetComponent<FightMaster>().winGame();
        base.Destroy();
        GameObject.Destroy(gameObject);
    }
}
