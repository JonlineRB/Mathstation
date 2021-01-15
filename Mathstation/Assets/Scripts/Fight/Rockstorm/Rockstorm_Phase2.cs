using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase2 : MonoBehaviour
{
    [SerializeField]
    private float interRockInterval;
    [SerializeField]
    private GameObject rocksToThrow;
    [SerializeField]
    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowRocks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRock(){
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
}
