using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_1 : MonoBehaviour
{
    [SerializeField]
    private string[] texts;
    [SerializeField]
    private GameObject textObject;
    private int index = 0;    

    void Start(){
        textObject.GetComponent<Text>().text = texts[index];
        Time.timeScale=0;
    }

    public void Next(){
        if(index==texts.Length-1){
            Close();
        }
        else
            textObject.GetComponent<Text>().text = texts[++index];
    }

    void Close(){
        GameObject fightGame = GameObject.Find("FightGame");
        fightGame.GetComponent<FightMaster>().ActivateOpponent();
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        Time.timeScale=1f;
        GameObject.Destroy(gameObject);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0))
            Next();
        if(Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
}
