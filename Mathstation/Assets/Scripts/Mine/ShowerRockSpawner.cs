using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerRockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private float interSpawnInterval;
    [SerializeField]
    private int amtOfRocks;

    void OnEnable(){
        //start coroutine here
        StartCoroutine("SpawnRocks");
    }

    private IEnumerator SpawnRocks(){
        for(int i = 0; i < amtOfRocks; i++){
            //add some modifiers: some should be in front of the roid, some behind, different sizes
            GameObject currentRock = GameObject.Instantiate(rock,transform.position, Quaternion.identity);
            //Randomly shove the rocks along the spawn axis
            currentRock.transform.Translate(new Vector3(Random.Range(-9,9),0,Mathf.Pow(-1f, i) * -4));
            currentRock.GetComponent<Move>().SetTranslateVector(new Vector3(Random.Range(0.17f, 0.8f) * Mathf.Pow(-1f, i),-1));
            yield return new WaitForSeconds(interSpawnInterval);
        }
        gameObject.SetActive(false);
    }
}
