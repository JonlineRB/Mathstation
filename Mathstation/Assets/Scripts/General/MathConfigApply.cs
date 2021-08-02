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

        // Write the policies to a configuration file
        PolicyObject policy = new PolicyObject();

        policy.remainderDivision = remainderDivision.isOn;
        policy.negativeValues = negativeValues.isOn;
        policy.textProblems = textProblems.isOn;
        policy.includeMultiplication = multiplication.isOn;
        policy.includeDivision = division.isOn;
        policy.includeFractions = fraction.isOn;
        policy.singleOperation = singleOperation.isOn;
        policy.simplifyFractions = simplifyFractions.isOn;

        if(!File.Exists(mathConfigFile)){
            File.Create(mathConfigFile);
        }

        File.WriteAllText(mathConfigFile, JsonUtility.ToJson(policy, true));

        // Close window
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
        mathConfigFile = Path.Combine(Application.streamingAssetsPath, "MathConfig.json");

        // If a config file exists, read from it and apply it's values to the toggles managed here as fields.

        if(!File.Exists(mathConfigFile))
            return;

        PolicyObject configPolicies;

        string configContent = File.ReadAllText(mathConfigFile);
        configPolicies = JsonUtility.FromJson<PolicyObject>(configContent);

        // Apply to toggle values

        remainderDivision.isOn = configPolicies.remainderDivision;
        negativeValues.isOn = configPolicies.negativeValues;
        textProblems.isOn = configPolicies.textProblems;
        multiplication.isOn = configPolicies.includeMultiplication;
        division.isOn = configPolicies.includeDivision;
        fraction.isOn = configPolicies.includeFractions;
        singleOperation.isOn = configPolicies.singleOperation;
        simplifyFractions.isOn = configPolicies.simplifyFractions;

    }
}