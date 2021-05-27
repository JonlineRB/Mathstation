using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Artifact super class
public class Artifact_Super : MonoBehaviour, MathCaller
{
    [SerializeField] protected GameObject mathEditor; //math editor reference
    [SerializeField] protected GameObject background;
    protected bool solved = false; //Turns true once math problem solved

    protected virtual void Action(){
        GameObject player = GameObject.Find("Player");
        // player.GetComponent<MoveLock>().setMoveLock(false);
        player.GetComponent<MoveLock>().DecrementMoveLock();
        player.GetComponent<Reset>().DecrementLockReset();
    } //action taken when player interacts after solving math
    protected virtual void Resolve(){} //single time actions taken after math is solved
    protected virtual void Exit(){} //return to normal once the player leaves the artifact

    void OnTriggerEnter2D(Collider2D other){
        GameObject player = GameObject.Find("Player");
        player.GetComponent<MoveLock>().IncrementMoveLock();
        player.GetComponent<Reset>().IncrementLockReset();
        //put player in the center of the object
        other.GetComponent<ArtifactInterpolation>().InitInterpolation(transform.position);

        if(!solved){
            CallMathEditor(); //if math not solved yet, open math question
        }
        else{
            Action(); //else do the artifact specified action
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        Exit(); //perform exit actions
    }

    //calls math editor with a generated problem
    public void CallMathEditor()
    {
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    //called when math has been solved
    public void MathSuccess()
    {
        solved = true;
        Resolve();
        Action();
    }
}
