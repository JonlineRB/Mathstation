using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Script for the QuizShow stage of fight game
public class QuizShow : MonoBehaviour
{
    private int operand_a; // left operand
    private int operand_b; // right operand
    private bool aGreaterB; // inequality sign. True is >, false is <
    [SerializeField]
    private GameObject textField; // Text object to which the problem is pushed
    [SerializeField]
    // True and false button gameObject references
    private GameObject vButton;
    [SerializeField]
    private GameObject xButton;
    [SerializeField]
    // Sprite references
    private Sprite idle;
    [SerializeField]
    private Sprite quiz;
    [SerializeField]
    private Sprite laugh;
    [SerializeField]
    private float initDuration; // Duration for question generation
    private bool isIdle = true;
    [SerializeField]
    private int nrgGain;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private int nrgDrainWrongAnswer;
    [SerializeField]
    private List<GameObject> amps; //List of amp objects
    [SerializeField]
    private float attackInterval;
    // Sets of other amps, introduced in the later phases of the fight
    [SerializeField]
    private GameObject Set2;
    [SerializeField]
    private GameObject Set3;

    // Call initiation, attack coroutines at the start
    void Start(){
        StartCoroutine("Initiate");
        StartCoroutine("Attack");
    }

    // Transition from idle to quiz mode
    public void toQuizMode(){
        gameObject.GetComponent<SpriteRenderer>().sprite=quiz;
        // Enable input buttons
        vButton.SetActive(true);
        xButton.SetActive(true);
        isIdle = false;
        gameObject.GetComponent<MouseOverCursorChange>().Lock();
        // If it's the final stage, swap the position of the input buttons
        if(life==1)
            SwapButtons();
    }

    // Transition to idle mode
    public void toIdleMode(){
        gameObject.GetComponent<SpriteRenderer>().sprite=idle;
        textField.GetComponent<Text>().text="";
        // Disable input buttons
        vButton.SetActive(false);
        xButton.SetActive(false);
        isIdle=true;
        gameObject.GetComponent<MouseOverCursorChange>().Unlock();
        StartCoroutine("Initiate");
    }

    // Generates question,
    // pushes text value to text object,
    // transitions to quiz mode
    public void GenerateStatement(){
        string result = "";
        operand_a = Random.Range(1,11);
        operand_b = Random.Range(1,11);
        while(operand_a==operand_b)
            operand_b = Random.Range(1,11);
        
        int decideGreater = Random.Range(0,2);
        switch (decideGreater){
            case 0:
                aGreaterB = true;
                break;
            case 1:
                aGreaterB = false;
                break;
        }

        result += operand_a;
        if(aGreaterB)
            result+=">";
        else
            result+="<";
        
        result += operand_b;

        textField.GetComponent<Text>().text = result;

        toQuizMode();

    }
    // Flush text object's text value
    public void ClearText(){
        textField.GetComponent<Text>().text="";
    }
    // Evaluates the values from GenerateStatement()
    public bool evaluateStatement(){
        if(aGreaterB)
            return operand_a>operand_b;
        else
            return operand_a<operand_b;
    }

    // Coroutine waits before calling GenerateStatement()
    private IEnumerator Initiate(){
        yield return new WaitForSeconds(initDuration);
        GenerateStatement();
    }

    // Automatically initiate attacks over time. Calls an amp's InitAttack()
    private IEnumerator Attack(){
        while(true){
            yield return new WaitForSeconds(attackInterval);
            Debug.Log(amps.Count);
            amps[Random.Range(0,amps.Count)].GetComponent<Amp>().InitAttack();
        }
    }
    // Handles player clicks
    void OnMouseDown(){
        if(isIdle){
            bool consumed = GameObject.Find("FightGame").GetComponent<FightMaster>().consumeEnergyCharge();
            if(consumed){
                //call math editor
                gameObject.GetComponent<QuizShow_Mathcaller>().CallMathEditor();
                GameObject.Find("FightGame").GetComponent<FightMaster>().setPauseCharging();
                StopAllCoroutines();
                isIdle=false;
                gameObject.GetComponent<MouseOverCursorChange>().Lock();
            }
            else
                GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(nrgGain);
        }
    }

    // Handles player shooting the true button
    public void vButtonClick(){
        if(evaluateStatement()){
            toIdleMode();
        }
        else
            WrongAnswer();
    }

    // Handles player shooting the false button
    public void xButtonClick(){
        if(!evaluateStatement()){
            toIdleMode();
        }
        else
            WrongAnswer();
    }

    // Called when the player answered incorrectly
    private void WrongAnswer(){
        gameObject.GetComponent<SpriteRenderer>().sprite=laugh;
        ClearText();
        xButton.SetActive(false);
        vButton.SetActive(false);
        StartCoroutine("Initiate");
        GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(-nrgDrainWrongAnswer);
        
        //attack with a random amp
        int index = Random.Range(0,amps.Count);
        bool taken = amps[index].GetComponent<Amp>().IsAttackig();
        while(taken){
            index = (index + 1) % amps.Count;
            taken = amps[index].GetComponent<Amp>().IsAttackig();
        }
        amps[index].GetComponent<Amp>().InitAttack();
    }
    
    // Called once math has been solved successfuly
    public void MathSuccess(){

        // Win if the life is reduced to zero or less
        if(--life<=0){
            GameObject.Find("FightGame").GetComponent<FightMaster>().winGame();
            GameObject.Destroy(gameObject);
        }

        //enable gun sprites
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Unlock();
            
        switch (life){
            case 2:
                Set2.SetActive(true);
                foreach(Transform child in Set2.transform)
                    amps.Add(child.gameObject);
                break;
            case 1:
                Set3.SetActive(true);
                foreach(Transform child in Set3.transform)
                    amps.Add(child.gameObject);
                break;
        }
        isIdle=true;
        gameObject.GetComponent<MouseOverCursorChange>().Unlock();
        GameObject.Find("FightGame").GetComponent<FightMaster>().releasePauseCharging();
        StartCoroutine("Initiate");
        StartCoroutine("Attack");
    }

    // Swaps the true and falls buttons.
    // Internally, it swaps the button's sprites and values
    public void SwapButtons(){
        vButton.GetComponent<QuizShowButton>().Swap();
        xButton.GetComponent<QuizShowButton>().Swap();
    }
}
