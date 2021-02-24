using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Super : MonoBehaviour
{
    [SerializeField]
    private string[] texts;
    [SerializeField]
    private GameObject textObject;
    private int index = 0;
    [SerializeField]
    private List<GameObject> assistObjects = new List<GameObject>();

    public virtual void OnEnable(){
        textObject.GetComponent<Text>().text = texts[index];
        Time.timeScale=0;

        if(assistObjects[0])
            assistObjects[0].SetActive(true);
    }

    public void Next(){
        if(index==texts.Length-1){
            Close();
            return;
        }

        if(assistObjects[index]){
            assistObjects[index].SetActive(false);
        }

        textObject.GetComponent<Text>().text = texts[++index];
        
        if(assistObjects[index]){
            assistObjects[index].SetActive(true);
        }
    }

    public virtual void Close(){
        if(assistObjects[index])
            assistObjects[index].SetActive(false);
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
