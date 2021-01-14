using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorMaster : MonoBehaviour
{

    [SerializeField]
    public int problemCount;
    // Start is called before the first frame update

    [SerializeField]
    private GameObject problemCountObject;
    [SerializeField]
    private GameObject reportsTo;
    void Start()
    {
        //generate initial problem
        generateProblem();
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
        generateProblem();
    }

    private Problem generateProblem(){
        Problem problem = gameObject.GetComponent<ProblemGenerator>().generateProblem();
        gameObject.GetComponent<TextManager>().SetProblem(problem);
        return problem;
    }

    public void SetReport(GameObject report){
        reportsTo = report;
    }
}
