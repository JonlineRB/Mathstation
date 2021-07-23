using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script manages the text objects of the math editor
public class TextManager : MonoBehaviour
{

    private Problem problem;
    [SerializeField] private GameObject defualtTextObject;
    [SerializeField] private GameObject NoTextBasedMaster;
    [SerializeField] private GameObject TextBasedMaster;
    [SerializeField] private GameObject textBasedTextObject;

    public void SetProblem(Problem problem){
        this.problem = problem;
        generateText();
    }

    public void generateText(){
        // If the text based question policy is in place, use the text based tools instead
        if(GameObject.FindObjectOfType<Policy>().isTextProblems()){
            NoTextBasedMaster.SetActive(false);
            TextBasedMaster.SetActive(true);
            // Transform the problem into a text based item
            string textProblem = gameObject.GetComponent<TextQuestions>().ToTextProblem(this.problem);
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
