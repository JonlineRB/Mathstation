using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject : MonoBehaviour
{
    private string solution = "";

    private Problem currentProblem;

    public void concatinateSolution(int value){
        solution += value.ToString();
        Debug.Log("Solution is: " + solution);
    }

    public void backspace(){
        if(solution == "")
            return;
        solution = solution.Remove(solution.Length-1);
        Debug.Log("Solution is: " + solution);
    }

    public void setProblem(Problem problem){
        currentProblem = problem;
    }

    public void Submit(){
        if(solution == "")
            return;
        bool result;
        Number actualSolution = currentProblem.getSolution();
        result = actualSolution.Compare(int.Parse(solution));
        Debug.Log("submitted. result is " + result);
        if(result)
            gameObject.GetComponent<EditorMaster>().Submition();
        solution = "";
    }
}
