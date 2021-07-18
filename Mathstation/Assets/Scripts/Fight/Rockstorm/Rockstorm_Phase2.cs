using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rockstorm 2nd Phase script
public class Rockstorm_Phase2 : Rockstorm_Superclass
{
    [SerializeField]
    private float interRockInterval; // Interval for throwing a rock (Attacking the player)
    [SerializeField]
    protected GameObject rocksToThrow; // Reference to the rock prefab
    [SerializeField]
    protected float radius; // Radius around the boss on which the rocks are instantiated
    protected List<GameObject> rocks = new List<GameObject>();
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

    // Instantiates a rock
    protected virtual void SpawnRock(){
        int deg = Random.Range(0,360);
        Vector3 position = new Vector3(Mathf.Sin(deg), Mathf.Cos(deg), 0) * radius;
        GameObject rock = GameObject.Instantiate(rocksToThrow, position, Quaternion.identity);
        rocks.Add(rock);
    }

    // Periodically calls SpawnRock()
    IEnumerator ThrowRocks(){
        while(true){
            yield return new WaitForSeconds(interRockInterval);
            //Spawn a damaging rock
            SpawnRock();
        }
    }

    // If energy is consumed, destroy all rocks
    public override void Damage()
    {
        if(CheckConsumeEnergy()){
            StopAllCoroutines();
            foreach(GameObject rock in rocks){
                GameObject.Destroy(rock);
            }
        }
    }
}
