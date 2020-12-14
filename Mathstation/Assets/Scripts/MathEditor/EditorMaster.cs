using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMaster : MonoBehaviour
{

    public int problemCount = 3;
    // Start is called before the first frame update
    void Start()
    {

        //generate initial problem
        generateProblem();
    }

    public void Submition(){
        if(--problemCount <= 0){
            GameObject.Destroy(gameObject);
            return;
        }
        Debug.Log("problemCount is: " + problemCount);
        generateProblem();
    }

    private Problem generateProblem(){
        Problem problem = gameObject.GetComponent<ProblemGenerator>().generateProblem();
        gameObject.GetComponent<TextManager>().SetProblem(problem);
        return problem;
    }
}
