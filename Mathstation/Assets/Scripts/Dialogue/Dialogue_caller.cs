using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class initiates dialogue sequences
public class Dialogue_caller : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dialogues; // References to dialogue prefabs
    private int index = 0;

    // Calls the next dialogue sequence
    public void CallDialogue(){
        if(index>=dialogues.Length)
            return;
        GameObject.Instantiate(dialogues[index++],transform);
    }
}
