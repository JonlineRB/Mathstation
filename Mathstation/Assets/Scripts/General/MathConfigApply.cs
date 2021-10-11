using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// UI script, manages math configuration in the settings window of the main menu
public class MathConfigApply : MonoBehaviour
{
    // References for ui toggle elements
    [SerializeField] private Toggle remainderDivision;
    [SerializeField] private Toggle negativeValues;
    [SerializeField] private Toggle textProblems;
    [SerializeField] private Toggle multiplication;
    [SerializeField] private Toggle division;
    [SerializeField] private Toggle fraction;
    [SerializeField] private Toggle singleOperation;
    [SerializeField] private Toggle simplifyFractions;
    [SerializeField] private GameObject mathEditorPrefab;
    [SerializeField] private GameObject settingsWindow;
    private string mathConfigFile;

    public void Execute(){

        PlayerPrefs.SetInt("remainderDivision", ((remainderDivision.isOn) ? 1:0));
        PlayerPrefs.SetInt("negativeValues", ((negativeValues.isOn) ? 1:0));
        PlayerPrefs.SetInt("textProblems", ((textProblems.isOn) ? 1:0));
        PlayerPrefs.SetInt("includeMultiplication", ((multiplication.isOn) ? 1:0));
        PlayerPrefs.SetInt("includeDivision", ((division.isOn) ? 1:0));
        PlayerPrefs.SetInt("includeFractions", ((fraction.isOn) ? 1:0));
        PlayerPrefs.SetInt("singleOperation", ((singleOperation.isOn) ? 1:0));
        PlayerPrefs.SetInt("simplifyFractions", ((simplifyFractions.isOn) ? 1:0));

        settingsWindow.SetActive(false);
    }

    void Update(){
        // Illegal policy combinations will lead to the button being uninteractible.
        // Reverting these will make the apply button interactible again.
        if(
            (remainderDivision.isOn && (negativeValues.isOn || fraction.isOn)) ||
            (textProblems.isOn && !singleOperation.isOn))
            {

                gameObject.GetComponent<Button>().interactable = false;

        }
        else
            gameObject.GetComponent<Button>().interactable = true;
    }

    void Awake(){

        // Apply to toggle values

        remainderDivision.isOn = PlayerPrefs.GetInt("remainderDivision")==1;
        negativeValues.isOn = PlayerPrefs.GetInt("negativeValues")==1;
        textProblems.isOn = PlayerPrefs.GetInt("textProblems")==1;
        multiplication.isOn = PlayerPrefs.GetInt("includeMultiplication")==1;
        division.isOn = PlayerPrefs.GetInt("includeDivision")==1;
        fraction.isOn = PlayerPrefs.GetInt("includeFractions")==1;
        singleOperation.isOn = PlayerPrefs.GetInt("singleOperation")==1;
        simplifyFractions.isOn = PlayerPrefs.GetInt("simplifyFrations")==1;

    }
}