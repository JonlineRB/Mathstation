using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for problem generation
public class ProblemGenerator : MonoBehaviour
{
    // Generate a problem and return it
    public Problem generateProblem()
    {
        Problem problem = new Problem();
        Debug.Log(problem.ToString(true));
        gameObject.GetComponent<InputObject>().setProblem(problem);
        return problem;
    }
}