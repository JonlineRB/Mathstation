using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockstorm_Phase1_MathCaller : MonoBehaviour, MathCaller
{
    [SerializeField]
    private GameObject mathEditor;

    public void CallMathEditor(){
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }
    
    public void MathSuccess(){
        gameObject.GetComponent<Rockstorm_Rock>().RecieveMathDamage();
    }
}
