using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void MathSuccess(){
        gameObject.GetComponent<QuizShow>().MathSuccess();
    }
    
}
