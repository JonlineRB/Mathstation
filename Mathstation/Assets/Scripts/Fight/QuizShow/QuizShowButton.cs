using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizShowButton : MonoBehaviour
{
    [SerializeField]
    private bool isVButton;
    [SerializeField]
    private Sprite v;

    [SerializeField]
    private Sprite x;

    void OnMouseDown(){
        if(isVButton)
            GameObject.Find("QuizShow").GetComponent<QuizShow>().vButtonClick();
        else
            GameObject.Find("QuizShow").GetComponent<QuizShow>().xButtonClick();
    }

    public void Swap(){
        isVButton = !isVButton;
        //change textures
        if(isVButton)
            gameObject.GetComponent<SpriteRenderer>().sprite = v;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = x;
    }
    
}
