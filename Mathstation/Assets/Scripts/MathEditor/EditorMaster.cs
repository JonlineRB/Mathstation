using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorMaster : MonoBehaviour
{

    [SerializeField]
    public int problemCount = 3;
    // Start is called before the first frame update

    [SerializeField]
    private GameObject problemCountObject;
    void Start()
    {
        //generate initial problem
        generateProblem();
        problemCountObject.GetComponent<Text>().text = problemCount.ToString();
    }

    public void Submition(){
        DecrementProblemCount();
        Debug.Log("problemCount is: " + problemCount);
        generateProblem();
    }

    private void DecrementProblemCount(){
        if(--problemCount <= 0){
            GameObject.Destroy(gameObject);
            return;
        }
        problemCountObject.GetComponent<Text>().text = problemCount.ToString();
    }

    private Problem generateProblem(){
        Problem problem = gameObject.GetComponent<ProblemGenerator>().generateProblem();
        gameObject.GetComponent<TextManager>().SetProblem(problem);
        return problem;
    }
}
