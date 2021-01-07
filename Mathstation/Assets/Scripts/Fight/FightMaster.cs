using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject mathEditor;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private GameObject opponent;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<HeartManager>().setHearts(2);
    }

    // Update is called once per frame
    void Update()
    {

        //temporary key bound events
        if(Input.GetKeyDown(KeyCode.D)){
            DecrementLife();
        }

    }

    //events
    public void DecrementLife(){
        if(--life<=0)
            Debug.Log("Game Over!");
        Debug.Log("Life is: " + life);
    }

    public void callEditor(){
        GameObject.Instantiate(mathEditor);
    }

    public void mathSuccess(){
    }

    public void mathFail(){

    }

    public void winGame(){

    }

    public void mainMenu(){}

    
}
