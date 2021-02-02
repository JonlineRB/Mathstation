using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start(){
        StartCoroutine("Initiate");
    }

    public void toQuizMode(){
        gameObject.GetComponent<SpriteRenderer>().sprite=quiz;
        vButton.SetActive(true);
        xButton.SetActive(true);
        isIdle = false;
    }
    public void toIdleMode(){
        gameObject.GetComponent<SpriteRenderer>().sprite=idle;
        vButton.SetActive(false);
        xButton.SetActive(false);
        isIdle=true;
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
            result+="<";
        else
            result+=">";
        
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

    void OnMouseDown(){
        if(isIdle){
            GameObject.Find("FightGame").GetComponent<FightMaster>().energyGain(nrgGain);
        }
    }

    public void vButtonClick(){}

    public void xButtonClick(){}

}
