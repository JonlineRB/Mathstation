﻿using System.Collections;
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

    public void Fraction(){
        if(!solution.Contains("/") && !solution.Contains("R") && solution.Length > 0)
            solution+="/";
            Debug.Log("Solution is: " + solution);
    }

    public void Negative(){
        if(!solution.Contains("-"))
            solution = "-" + solution;
        else
            solution = solution.Split('-')[1];
        Debug.Log("Solution is: " + solution);
    }

    public void Remainder(){
        if(!solution.Contains("R") && !solution.Contains("/") && solution.Length > 0)
            solution+="R";
        Debug.Log("Solution is: " + solution);
    }

    public void Submit(){
        if(solution == "")
            return;
        bool result;
        Number actualSolution = currentProblem.getSolution();
        if(solution.Contains("/"))
            result = actualSolution.Compare(new Number(int.Parse(solution.Split('/')[0]),int.Parse(solution.Split('/')[1])));
        else if(solution.Contains("R")){
            Number number = new Number(int.Parse(solution.Split('R')[0]));
            number.setRemainder(int.Parse(solution.Split('R')[1]));
            result = actualSolution.Compare(number);
        }
        else
            result = actualSolution.Compare(new Number(int.Parse(solution)));
        Debug.Log("submitted. result is " + result);
        if(result)
            gameObject.GetComponent<EditorMaster>().Submition();
        solution = "";
    }
}
