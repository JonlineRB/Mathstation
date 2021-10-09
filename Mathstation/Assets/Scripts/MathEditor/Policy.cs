using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// Math policies that dictate problem generation
public class Policy : MonoBehaviour
{
    [SerializeField] private bool remainderDivision;
    [SerializeField] private bool negativeValues;
    [SerializeField] private bool textProblems;
    [SerializeField] private bool includeMultiplication;
    [SerializeField] private bool includeDivision;
    [SerializeField] private bool includeFractions;
    [SerializeField] private bool singleOperation;
    [SerializeField] private bool simplifyFractions;
    [SerializeField] private GameObject policyTextObject;
    private PolicyObject configPolicies;

    public bool isSingleOperation()
    {
        return this.singleOperation;
    }

    public void setSingleOperation(bool singleOperation)
    {
        this.singleOperation = singleOperation;
    }


    public bool isIncludeFractions()
    {
        return this.includeFractions;
    }

    public void setIncludeFractions(bool includeFractions)
    {
        this.includeFractions = includeFractions;
    }

    public bool isRemainderDivision()
    {
        return this.remainderDivision;
    }

    public void setRemainderDivision(bool remainderDivision)
    {
        this.remainderDivision = remainderDivision;
    }

    public bool isNegativeValues()
    {
        return this.negativeValues;
    }

    public void setNegativeValues(bool negativeValues)
    {
        this.negativeValues = negativeValues;
    }

    public bool isTextProblems()
    {
        return this.textProblems;
    }

    public void setTextProblems(bool textProblems)
    {
        this.textProblems = textProblems;
    }

    public bool isIncludeMultiplication()
    {
        return this.includeMultiplication;
    }

    public void setIncludeMultiplication(bool includeMultiplication)
    {
        this.includeMultiplication = includeMultiplication;
    }

    public bool isIncludeDivision()
    {
        return this.includeDivision;
    }

    public void setIncludeDivision(bool includeDivision)
    {
        this.includeDivision = includeDivision;
    }

    public bool isSimplifyFractions()
    {
        return this.simplifyFractions;
    }

    public void setSimplifyFractions(bool simplifyFractions)
    {
        this.simplifyFractions = simplifyFractions;
    }

    void Awake(){
        // Get the math config info from the config file MathConfig.json in persistentDataPath

        // string configFile = Path.Combine(Application.persistentDataPath, "MathConfig.json");
        
        // if(File.Exists(configFile)){
        //     string configFileContent = File.ReadAllText(configFile);
        //     configPolicies = JsonUtility.FromJson<PolicyObject>(configFileContent);

            // Set all policies
            // remainderDivision = configPolicies.remainderDivision;
            // negativeValues = configPolicies.negativeValues;
            // textProblems = configPolicies.textProblems;
            // includeMultiplication = configPolicies.includeMultiplication;
            // includeDivision = configPolicies.includeDivision;
            // includeFractions = configPolicies.includeFractions;
            // singleOperation = configPolicies.singleOperation;
            // simplifyFractions = configPolicies.simplifyFractions;
        // }

        remainderDivision = PlayerPrefs.GetInt("remainderDivision")==1;
        negativeValues = PlayerPrefs.GetInt("negativeValues")==1;
        textProblems = PlayerPrefs.GetInt("textProblems")==1;
        includeMultiplication = PlayerPrefs.GetInt("includeMultiplication")==1;
        includeDivision = PlayerPrefs.GetInt("includeDivision")==1;
        includeFractions = PlayerPrefs.GetInt("includeFractions")==1;
        singleOperation = PlayerPrefs.GetInt("singleOperation")==1;
        simplifyFractions = PlayerPrefs.GetInt("simplifyFractions")==1;

    }

    void Start()
    {
        string result = "";
        if(remainderDivision)
            result += "Remainder Division\n";
        else if(includeDivision)
            result += "Fraction Division\n";
        if(negativeValues)
            result += "Negative Values Allowed\n";
        else
            result += "No Negative Values\n";
        if(includeFractions)
            result += "Includes Fractions\n";

        // Push some policiy related text to a UI element
        // Helps the user understand the current rule set
        policyTextObject.GetComponent<Text>().text = result;
    }
}
