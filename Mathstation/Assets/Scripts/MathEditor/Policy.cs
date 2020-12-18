﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Policy : MonoBehaviour
{
    [SerializeField]
    private bool remainderDivision;
    [SerializeField]
    private bool negativeValues;
    [SerializeField]
    private bool textProblems;
    [SerializeField]
    private bool includeMultiplication;
    [SerializeField]
    private bool includeDivision;
    [SerializeField]
    private bool includeFractions;
    [SerializeField]
    private bool singleOperation;
    [SerializeField]
    private GameObject policyTextObject;

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

    // Start is called before the first frame update
    void Start()
    {
        string result = "";
        if(remainderDivision)
            result += "Remainder Division\n";
        else if(includeDivision)
            result += "Fraction Division\n";
        if(negativeValues)
            result += "Negative Values\n";
        else
            result += "No Negative Values\n";
        if(includeFractions)
            result += "Includes Fractions\n";

        policyTextObject.GetComponent<Text>().text = result;
    }
}
