using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompositeSpriteObject : MonoBehaviour
{

    private SpriteManager spriteManager;
    private Sprite[] sprites;
    private Number value;

    private MathOperations.Operations operation;

    [SerializeField]
    private GameObject Symbol;
    
    // Start is called before the first frame update
    void Start()
    {
        //get the value
        //init the sprites
        //lay the sprites out
        spriteManager = gameObject.GetComponentInParent<SpriteManager>();
        SetValue(new Number(0));
    }

    public void SetValue(Number value){
        this.value = value;
        //get necessary sprites here
        SetSprites();
    }

    private void SetSprites(){
        int spriteCount = value.ToString().Length;
        sprites = new Sprite[spriteCount];
        //iterate over the array, generate symbols
        Sprite sprite = spriteManager.GetSprite("(");
        GameObject symbol = GameObject.Instantiate(Symbol, transform.position, Quaternion.identity, transform);
        symbol.GetComponent<Image>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
