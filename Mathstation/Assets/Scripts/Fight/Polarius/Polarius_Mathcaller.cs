using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mathcaller script for Polarius stage in fight game
public class Polarius_Mathcaller : MonoBehaviour, MathCaller
{
    [SerializeField]
    private GameObject mathEditor;

    public void CallMathEditor(){
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    public void MathSuccess(){
        gameObject.GetComponent<Polarius>().MathSuccess();
        //enable gun sprites
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Unlock();
    }
}
