using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mathcaller script for QuizShow stage of fight game
public class QuizShow_Mathcaller : MonoBehaviour, MathCaller
{
    [SerializeField]
    private GameObject mathEditor;

    public void CallMathEditor(){
        //disable gun sprites
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Lock();

        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    // Called once math is successfuly solved
    public void MathSuccess(){
        gameObject.GetComponent<QuizShow>().MathSuccess();
    }
    
}
