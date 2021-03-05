using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
