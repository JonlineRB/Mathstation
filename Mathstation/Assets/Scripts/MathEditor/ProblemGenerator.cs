using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    public Problem generateProblem()
    {
        Problem problem = new Problem();
        Debug.Log(problem.ToString());
        return problem;
    }

    void Start(){
        Problem problem = generateProblem();
        gameObject.GetComponent<SpriteManager>().SetSprites(problem.ToString());
    }
}