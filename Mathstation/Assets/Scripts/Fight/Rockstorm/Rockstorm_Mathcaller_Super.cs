using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Mathcaller_Super : MonoBehaviour, MathCaller
{
    [SerializeField]
    private GameObject mathEditor;

    public void CallMathEditor(){
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }
    
    public virtual void MathSuccess(){}//override this with the specific call to the gameobject's script
}
