using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for QuizzShow's button objects
public class QuizShowButton : MonoBehaviour
{
    [SerializeField]
    private bool isVButton; // Determines if the button is a true or a flase button
    // Sprite references
    [SerializeField]
    private Sprite v;

    [SerializeField]
    private Sprite x;

    // Handles mouse clicks
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
