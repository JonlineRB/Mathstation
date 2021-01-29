using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_caller : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dialogues;
    private int index = 0;

    public void CallDialogue(){
        if(index>=dialogues.Length)
            return;
        GameObject.Instantiate(dialogues[index++],transform);
    }
}
