using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Super class for dialogue management
public class Dialogue_Super : MonoBehaviour
{
    [SerializeField]
    private string[] texts; // Speech bubble contents. Use editor to edit them per scene
    [SerializeField]
    private GameObject textObject; // The text object to which values are pushed for display
    private int index = 0;
    [SerializeField]
    private List<GameObject> assistObjects = new List<GameObject>(); // Optional arrows to point at in game elements. Use in editor

    public virtual void OnEnable(){
        textObject.GetComponent<Text>().text = texts[index];
        Time.timeScale=0;

        if(assistObjects.Count==0)
            return;

        // Activate first assist object if present
        if(assistObjects[0])
            assistObjects[0].SetActive(true);
    }

    public void Next(){
        // If the last line is reached, Next() will close the dialogue window
        if(index==texts.Length-1){
            Close();
            return;
        }

        // Disable previous assistObject if present
        if(index<assistObjects.Count && assistObjects[index]){
            assistObjects[index].SetActive(false);
        }

        textObject.GetComponent<Text>().text = texts[++index];

        // Enable assistObject if present for that message
        if(index<assistObjects.Count && assistObjects[index]){
            assistObjects[index].SetActive(true);
        }
    }

    // Closes the dialogue system and resumes flow of time
    public virtual void Close(){
        if(index < assistObjects.Count && assistObjects[index])
            assistObjects[index].SetActive(false);
        Time.timeScale=1f;
        GameObject.Destroy(gameObject);
    }

    // Controls
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0))
            Next();
        if(Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
}
