using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRocks : MonoBehaviour
{
    [SerializeField]
    private GameObject stone;
    [SerializeField]
    private int amtOfStones;

    public void Explode(Vector3 position){
        for(int i = 0; i <= amtOfStones; i++){
            GameObject.Instantiate(stone, position, Quaternion.identity);
        }
    }

    public void Explode(Vector3 position, int amt){
        for(int i = 0; i <= amt; i++){
            GameObject.Instantiate(stone, position, Quaternion.identity);
        }
    }
}
