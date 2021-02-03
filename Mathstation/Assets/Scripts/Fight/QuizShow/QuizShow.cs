﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizShow : MonoBehaviour
{
    private int operand_a;
    private int operand_b;
    private bool aGreaterB;
    [SerializeField]
    private GameObject textField;
    [SerializeField]
    private GameObject vButton;
    [SerializeField]
    private GameObject xButton;
    [SerializeField]
    private Sprite idle;
    [SerializeField]
    private Sprite quiz;
    [SerializeField]
    private float initDuration;
    private bool isIdle = true;
    [SerializeField]
    private int nrgGain;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private Sprite laugh;
    [SerializeField]
    private int nrgDrainWrongAnswer;
    [SerializeField]
    private List<GameObject> amps;
    [SerializeField]
    private float attackInterval;
    [SerializeField]
    private GameObject Set2;
    [SerializeField]
    private GameObject Set3;

    void Start(){
        StartCoroutine("Initiate");
        StartCoroutine("Attack");
    }

    public void toQuizMode(){
        gameObject.GetComponent<SpriteRenderer>().sprite=quiz;
        vButton.SetActive(true);
        xButton.SetActive(true);
        isIdle = false;
    }
    public void toIdleMode(){
        gameObject.GetComponent<SpriteRenderer>().sprite=idle;
        textField.GetComponent<Text>().text="";
        vButton.SetActive(false);
        xButton.SetActive(false);
        isIdle=true;
        StartCoroutine("Initiate");
    }
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
    public void ClearText(){
        textField.GetComponent<Text>().text="";
    }
    public bool evaluateStatement(){
        if(aGreaterB)
            return operand_a>operand_b;
        else
            return operand_a<operand_b;
    }

    private IEnumerator Initiate(){
        yield return new WaitForSeconds(initDuration);
        GenerateStatement();
    }

    private IEnumerator Attack(){
        while(true){
            yield return new WaitForSeconds(attackInterval);
            Debug.Log(amps.Count);
            amps[Random.Range(0,amps.Count)].GetComponent<Amp>().InitAttack();
            // amps[1].GetComponent<Amp>().InitAttack();
        }
    }
    void OnMouseDown(){
        if(isIdle){
            bool consumed = GameObject.Find("FightGame").GetComponent<FightMaster>().consumeEnergyCharge();
            if(consumed){
                //call math editor
                gameObject.GetComponent<QuizShow_Mathcaller>().CallMathEditor();
                GameObject.Find("FightGame").GetComponent<FightMaster>().setPauseCharging();
                StopAllCoroutines();
                isIdle=false;
            }
            else
                GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(nrgGain);
        }
    }

    public void vButtonClick(){
        if(evaluateStatement()){
            toIdleMode();
        }
        else
            WrongAnswer();
    }

    public void xButtonClick(){
        if(!evaluateStatement()){
            toIdleMode();
        }
        else
            WrongAnswer();
    }

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
    public void MathSuccess(){
        if(--life<=0)
            SceneManager.LoadScene("WinScene");
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
        GameObject.Find("FightGame").GetComponent<FightMaster>().releasePauseCharging();
        StartCoroutine("Initiate");
        StartCoroutine("Attack");
    }
}
