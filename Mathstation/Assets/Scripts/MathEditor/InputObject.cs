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

    public void submit(){
        if(solution == "")
            return;
        bool result;
        // int actualSolution = gameObject.GetComponent<Problem>().getSolution();
        int actualSolution = currentProblem.getSolution();
        result = (int.Parse(solution) == actualSolution);
        Debug.Log("submitted. result is " + result);
    }
}
