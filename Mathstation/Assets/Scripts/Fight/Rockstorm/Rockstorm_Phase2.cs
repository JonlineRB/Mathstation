using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase2 : MonoBehaviour
{
    [SerializeField]
    private float interRockInterval;
    [SerializeField]
    private GameObject rocksToThrow;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowRocks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThrowRocks(){
        while(true){
            yield return new WaitForSeconds(interRockInterval);
            //Spawn a damaging rock
            Debug.Log("Rock Spawned");
        }
    }
}
