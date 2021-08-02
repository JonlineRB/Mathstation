using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script randomizes sprite for an object with sprite renderer component
public class RandomizeSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites; // References for possible sprites

    // Start is called before the first frame update
    void Start()
    {
        if(sprites.Length == 0)
            return;
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }
}
