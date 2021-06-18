using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathConfigApply : MonoBehaviour
{
    [SerializeField] private Toggle remainderDivision;
    [SerializeField] private Toggle negativeValues;
    [SerializeField] private Toggle textProblems;
    [SerializeField] private Toggle multiplication;
    [SerializeField] private Toggle division;
    [SerializeField] private Toggle fraction;
    [SerializeField] private Toggle singleOperation;
    [SerializeField] private Toggle simplifyFractions;
    [SerializeField] private GameObject mathEditorPrefab;

    public void Execute(){
        mathEditorPrefab.GetComponent<Policy>().setRemainderDivision(remainderDivision.isOn);
        mathEditorPrefab.GetComponent<Policy>().setNegativeValues(negativeValues.isOn);
        mathEditorPrefab.GetComponent<Policy>().setTextProblems(textProblems.isOn);
        mathEditorPrefab.GetComponent<Policy>().setIncludeMultiplication(multiplication.isOn);
        mathEditorPrefab.GetComponent<Policy>().setIncludeDivision(division.isOn);
        mathEditorPrefab.GetComponent<Policy>().setIncludeFractions(fraction.isOn);
        mathEditorPrefab.GetComponent<Policy>().setSingleOperation(singleOperation.isOn);
        mathEditorPrefab.GetComponent<Policy>().setSimplifyFractions(simplifyFractions.isOn);
    }

    void Update(){
        //Illegal policy combinations will lead to the button being uninteractible.
        //Reverting these will make the apply button interactible again.
        if(
            (remainderDivision.isOn && (negativeValues.isOn || fraction.isOn)) ||
            (textProblems.isOn && !singleOperation.isOn))
            {

                gameObject.GetComponent<Button>().interactable = false;

        }
        else
            gameObject.GetComponent<Button>().interactable = true;
    }
}