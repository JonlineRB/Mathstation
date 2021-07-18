using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script swaps sprites of game object
public class SpriteSwap : MonoBehaviour
{
    [SerializeField]
    private Sprite altSprite;
    [SerializeField]
    private float duration;
    [SerializeField]
    private int repeats;

    public void InitSwap(){
        StartCoroutine("Swap");
    }

    // Alternates between og sprite and altSprite
    private IEnumerator Swap(){
        Sprite og = gameObject.GetComponent<SpriteRenderer>().sprite;
        for(int i = 0; i < repeats; i++){
            gameObject.GetComponent<SpriteRenderer>().sprite = altSprite;
            yield return new WaitForSeconds(duration);
            gameObject.GetComponent<SpriteRenderer>().sprite = og;
            yield return new WaitForSeconds(duration);
        }
    }
}
