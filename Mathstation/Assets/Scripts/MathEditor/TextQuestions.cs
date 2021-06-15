using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextQuestions : MonoBehaviour
{
    [SerializeField] string[] addition_questions;
    [SerializeField] string[] subtraction_questions;
    [SerializeField] string[] multiplication_questions;
    [SerializeField] string[] division_questions;

    public string ToTextProblem(Problem problem){
        //break the problem string into tokens
        string problemString = problem.ToString(false); //has the shape of 1 Add 1
        if(problemString.Split(' ').Length!=3){
            Debug.Log("Length is not 3");
            return null;
        }

        string result = "";

        switch(problemString.Split(' ')[1]){
        case "Add":
            result = addition_questions[0];
            break;
        case "Sub":
            result = subtraction_questions[0];
            break;
        case "Mul":
            result = multiplication_questions[0];
            break;
        case "Div":
            result = division_questions[0];
            break;
        }

        result = result.Replace("VAL_A", problemString.Split(' ')[0]);
        result = result.Replace("VAL_B", problemString.Split(' ')[2]);

        Debug.Log(problem.ToString(false));
        return result;
    }


}
