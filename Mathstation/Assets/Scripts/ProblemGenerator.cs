using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    public Problem generateProblem()
    {
        Problem problem = new Problem();
        Debug.Log(problem.toString());
        return problem;
    }

    void Start(){
        generateProblem();
    }
}
