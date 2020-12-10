using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    public Problem generateProblem()
    {
        Problem problem = new Problem();
        Debug.Log(problem.ToString(true));
        gameObject.GetComponent<InputObject>().setProblem(problem);
        return problem;
    }
}