using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Mathcaller_Super : MonoBehaviour, MathCaller
{
    [SerializeField]
    private GameObject mathEditor;

    public void CallMathEditor(){
        //lock the gun sprites. prevents shooting effect in math editor
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Lock();
        //call math editor object
        GameObject editor = GameObject.Instantiate(mathEditor);
        //set the object that math editor reports to
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }
    
    public virtual void MathSuccess(){}//override this with the specific call to the gameobject's script
}
