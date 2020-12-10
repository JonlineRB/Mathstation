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
        Problem problem = gameObject.GetComponent<ProblemGenerator>().generateProblem();
        // gameObject.GetComponent<SpriteManager>().SetSprites(problem.ToString(false)); //removed due to poor sprite management. revise.
    }

    public void Submition(){
        if(--problemCount <= 0){
            GameObject.Destroy(gameObject);
            return;
        }
        Debug.Log("problemCount is: " + problemCount);
        gameObject.GetComponent<ProblemGenerator>().generateProblem();
    }
}
