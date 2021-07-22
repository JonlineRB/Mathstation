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
    [SerializeField] private bool isStandalone; // Is set to true in the math scene (no game, just math)
    void Start()
    {
        //generate initial problem
        GenerateProblem();

        if(isStandalone){
            problemCount = 0;
        }

        problemCountObject.GetComponent<Text>().text = problemCount.ToString();
    }

    public void Submition(){
        if(isStandalone)
            IncrementProblemCount();
        else
            DecrementProblemCount();
        Debug.Log("problemCount is: " + problemCount);
    }

    // Used in game to reduce the problem counts to 0, and close the editor
    private void DecrementProblemCount(){
        if(--problemCount <= 0){
            reportsTo.GetComponent<MathCaller>().MathSuccess();
            GameObject.Destroy(gameObject);
            return;
        }
        problemCountObject.GetComponent<Text>().text = problemCount.ToString();
        GenerateProblem();
    }

    // Used in standalone mode to count how many problems have been solved so far
    private void IncrementProblemCount(){
        problemCount++;
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
