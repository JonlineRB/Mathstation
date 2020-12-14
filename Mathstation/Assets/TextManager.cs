using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    private Problem problem;

    [SerializeField]
    private GameObject textObject;
    // private GameObject fractionObject; //for future fraction?

    public void SetProblem(Problem problem){
        this.problem = problem;
        generateText();
    }

    public void generateText(){
        string text = this.problem.ToString(false);
        // Debug.Log(text);
        // Debug.Log("Replacing stuff");
        text = text.Replace("Add","+");
        text = text.Replace("Sub","-");
        text = text.Replace("Mul","*");
        text = text.Replace("Div","/");
        // Debug.Log(text);
        // Debug.Log("Done replacing");
        textObject.GetComponentInParent<Text>().text = text;
    }
}
