﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextQuestions : MonoBehaviour
{

    [SerializeField] string[] additionQuestions;
    [SerializeField] string[] subtractionQuestions;
    [SerializeField] string[] multiplicationQuestions;
    [SerializeField] string[] divisionQuestions;
    
    // Pulls a text based problem from the text problem XML file
    public string ToTextProblem(Problem problem){
        // Break the problem string into tokens
        string problemString = problem.ToString(false); //has the shape of 1 Add 1
        if(problemString.Split(' ').Length!=3){
            Debug.Log("Length is not 3");
            return null;
        }

        string result = "";

        switch(problemString.Split(' ')[1]){
        case "Add":
            // result = addition_questions[0];
            // result = gameObject.GetComponent<XmlHandler>().FetchQuestion("addition");
            result = additionQuestions[Random.Range(0,additionQuestions.Length)];
            break;
        case "Sub":
            // result = subtraction_questions[0];
            // result = gameObject.GetComponent<XmlHandler>().FetchQuestion("subtraction");
            result = subtractionQuestions[Random.Range(0,subtractionQuestions.Length)];
            break;
        case "Mul":
            // result = multiplication_questions[0];
            // result = gameObject.GetComponent<XmlHandler>().FetchQuestion("multiplication");
            result = multiplicationQuestions[Random.Range(0,multiplicationQuestions.Length)];
            break;
        case "Div":
            // result = division_questions[0];
            // result = gameObject.GetComponent<XmlHandler>().FetchQuestion("division");
            result = divisionQuestions[Random.Range(0,divisionQuestions.Length)];
            break;
        }

        result = result.Replace("VAL_A", problemString.Split(' ')[0]);
        result = result.Replace("VAL_B", problemString.Split(' ')[2]);

        Debug.Log(problem.ToString(false));
        return result;
    }


}
