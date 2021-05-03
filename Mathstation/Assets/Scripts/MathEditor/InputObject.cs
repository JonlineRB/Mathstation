using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputObject : MonoBehaviour
{
    private string solution = "";
    private Problem currentProblem;
    [SerializeField]
    GameObject textObject;
    [SerializeField]
    private Sprite feedbackIdle;
    [SerializeField]
    private Sprite feedbackCorrect;
    [SerializeField]
    private Sprite feedbackWrong;
    [SerializeField]
    private GameObject feedbackObject;
    [SerializeField]
    private float feedbackChangeTime;

    public void concatinateSolution(int value){
        solution += value.ToString();
        // Debug.Log("Solution is: " + solution);
        PushTextObject(solution);
    }

    public void backspace(){
        if(solution == "")
            return;
        solution = solution.Remove(solution.Length-1);
        // Debug.Log("Solution is: " + solution);
        PushTextObject(solution);
    }

    public void setProblem(Problem problem){
        currentProblem = problem;
    }

    public void Fraction(){
        if(solution.Length == 0 || solution.Contains("R") || solution[solution.Length-1]=='-')
            return;
        if(solution[solution.Length-1] == '/')
            return;
        else if(solution.Split('/').Length -1 >= 2)
            return;
        solution+="/";
            // Debug.Log("Solution is: " + solution);
            PushTextObject(solution);
    }

    public void Negative(){
        Policy policy = GameObject.FindObjectOfType<Policy>();
        if(!policy.isNegativeValues())
            return;
        if(!solution.Contains("-"))
            solution = "-" + solution;
        else
            solution = solution.Split('-')[1];
        // Debug.Log("Solution is: " + solution);
        PushTextObject(solution);
    }

    public void Remainder(){
        if(!solution.Contains("R") && !solution.Contains("/") && solution.Length > 0)
            solution+="R";
        // Debug.Log("Solution is: " + solution);
        PushTextObject(solution);
    }

    public void Submit(){
        if(solution == "")
            return;
        bool result;
        Number actualSolution = currentProblem.getSolution();
        if(solution.Contains("/")){
            int count = solution.Split('/').Length -1;
            //case: only 1 fraction symbol
            if(count == 1){
                Debug.Log("DING count = 1");
                result = actualSolution.Compare(new Number(int.Parse(solution.Split('/')[0]),int.Parse(solution.Split('/')[1])));
            }
                
            else{
                int factor = solution.Contains("-") ? -1 : 1;
                Number basePart = new Number(int.Parse(solution.Split('/')[0]));
                int numerator = int.Parse(solution.Split('/')[1]) * factor;
                int denominator = int.Parse(solution.Split('/')[2]);
                Number fractionPart = new Number(numerator, denominator);
                Number sum = MathOperations.Add(basePart, fractionPart);
                result = actualSolution.Compare(sum);
            }
        }
            
        else if(solution.Contains("R")){
            Number number = new Number(int.Parse(solution.Split('R')[0]));
            number.setRemainder(int.Parse(solution.Split('R')[1]));
            result = actualSolution.Compare(number);
        }
        else
            result = actualSolution.Compare(new Number(int.Parse(solution)));
        Debug.Log("submitted. result is " + result);
        if(result){
            gameObject.GetComponent<EditorMaster>().Submition();
            StopAllCoroutines();
            StartCoroutine("FeedbackCorrect");
        }
        else{
            StopAllCoroutines();
            StartCoroutine("FeedbackWrong");
        }
            
            
        solution = "";
        PushTextObject("");
    }

    private void PushTextObject(string value){
        textObject.GetComponent<Text>().text = value;
    }

    public void ClearEverything(){
        solution = "";
        PushTextObject(solution);
    }

    IEnumerator FeedbackWrong(){
        feedbackObject.GetComponent<Image>().sprite = feedbackWrong;
        yield return new WaitForSecondsRealtime(feedbackChangeTime);
        feedbackObject.GetComponent<Image>().sprite = feedbackIdle;
    }

    IEnumerator FeedbackCorrect(){
        feedbackObject.GetComponent<Image>().sprite = feedbackCorrect;
        yield return new WaitForSecondsRealtime(feedbackChangeTime);
        feedbackObject.GetComponent<Image>().sprite = feedbackIdle;
    }
}
