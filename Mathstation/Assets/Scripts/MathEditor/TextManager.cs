using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    private Problem problem;

    [SerializeField]
    private GameObject defualtTextObject;
    [SerializeField]
    private GameObject NoTextBasedMaster;
    [SerializeField]
    private GameObject TextBasedMaster;
    [SerializeField]
    private GameObject textBasedTextObject;
    // private GameObject fractionObject; //for future fraction?

    public void SetProblem(Problem problem){
        this.problem = problem;
        generateText();
    }

    public void generateText(){
        //if the text based question policy is in place, use the text based tools instead
        if(GameObject.FindObjectOfType<Policy>().isTextProblems()){
            NoTextBasedMaster.SetActive(false);
            TextBasedMaster.SetActive(true);
            string textProblem = "This is long, a text based problem. This is long, a text based problem. This is long, a text based problem. This is long, a text based problem. ";
            textProblem += this.problem.ToString(false);
            textBasedTextObject.GetComponentInParent<Text>().text = textProblem;
            return;
        }
        TextBasedMaster.SetActive(false);
        NoTextBasedMaster.SetActive(true);
        string text = this.problem.ToString(false);
        // Debug.Log(text);
        // Debug.Log("Replacing stuff");
        text = text.Replace("Add","+");
        text = text.Replace("Sub","-");
        text = text.Replace("Mul","*");
        text = text.Replace("Div","/");
        defualtTextObject.GetComponentInParent<Text>().text = text;
    }
}
