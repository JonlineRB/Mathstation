using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPirateShips : MonoBehaviour
{
    [SerializeField]
    private GameObject pirateShip;
    [SerializeField]
    private float interSpawnInterval;
    [SerializeField]
    private int amtOfShips;

    void OnEnable(){
        //start coroutine here
        StartCoroutine("SpawnShips");
    }

    private IEnumerator SpawnShips(){
        for(int i = 0; i < amtOfShips; i++){
            //add some modifiers: some should be in front of the roid, some behind, different sizes
            GameObject currentShip = GameObject.Instantiate(pirateShip,transform.position, Quaternion.identity);
            currentShip.GetComponent<Move>().SetTranslateVector(new Vector3(-1, -0.17f * Mathf.Pow(-1f, i)));
            currentShip.transform.Translate(new Vector3(0,0,Mathf.Pow(-1f, i) * -4));
            yield return new WaitForSeconds(interSpawnInterval);
        }
        gameObject.SetActive(false);
    }
}
