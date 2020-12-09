﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathEditorInput : MonoBehaviour
{
    public Button[] buttons;

    private bool clickable = true;

    void Update(){
        if(!clickable)
            return;
        if(Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0)){
            propagate(0);
        }
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)){
            propagate(1);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)){
            propagate(2);
        }
        if(Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)){
            propagate(3);
        }
        if(Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)){
            propagate(4);
        }
        if(Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)){
            propagate(5);
        }
        if(Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6)){
            propagate(6);
        }
        if(Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7)){
            propagate(7);
        }
        if(Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8)){
            propagate(8);
        }
        if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9)){
            propagate(9);
        }
        if(Input.GetKeyDown(KeyCode.Backspace)){
            StartCoroutine("restoreClickable");
            gameObject.GetComponent<InputObject>().backspace();
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            StartCoroutine("restoreClickable");
            gameObject.GetComponent<InputObject>().submit();
        }
    }
    
    void propagate(int value){
        gameObject.GetComponent<InputObject>().concatinateSolution(value);
        StartCoroutine("restoreClickable");
    }

    IEnumerator restoreClickable(){
        clickable = false;
        yield return new WaitForSeconds(0.1f);
        clickable = true;
    }
}
