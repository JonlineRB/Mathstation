using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script flashes an object with a specified color through coroutine
public class FlashColor : MonoBehaviour
{
    // Color and coroutine values
    [SerializeField]
    private Color color;
    [SerializeField]
    private float interval;
    [SerializeField]
    private int repeats;

    public IEnumerator Flash(){
        Color og = gameObject.GetComponent<SpriteRenderer>().color;
        for(int i = 0; i < repeats; i++){
            Debug.Log("DING");
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(interval);
            gameObject.GetComponent<SpriteRenderer>().color = og;
            yield return new WaitForSeconds(interval);
        }
    }
}
