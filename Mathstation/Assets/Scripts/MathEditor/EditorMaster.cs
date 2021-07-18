using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Top level script for the math editor
public class EditorMaster : MonoBehaviour
{

    [SerializeField] public int problemCount;
    [SerializeField] private GameObject problemCountObject; // UI text value
    [SerializeField] private GameObject reportsTo; // Object to notify when math has been solved
    void Start()
    {
        //generate initial problem
        GenerateProblem();
        problemCountObject.GetComponent<Text>().text = problemCount.ToString();
    }

    public void Submition(){
        DecrementProblemCount();
        Debug.Log("problemCount is: " + problemCount);
    }

    private void DecrementProblemCount(){
        if(--problemCount <= 0){
            reportsTo.GetComponent<MathCaller>().MathSuccess();
            GameObject.Destroy(gameObject);
            return;
        }
        problemCountObject.GetComponent<Text>().text = problemCount.ToString();
        GenerateProblem();
    }

    private Problem GenerateProblem(){
        Problem problem = gameObject.GetComponent<ProblemGenerator>().generateProblem();
        gameObject.GetComponent<TextManager>().SetProblem(problem);
        return problem;
    }

    public void SetReport(GameObject report){
        reportsTo = report;
    }
}
