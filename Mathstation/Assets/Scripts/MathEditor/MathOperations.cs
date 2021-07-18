using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The math operations of the game and their interactions
public static class MathOperations
{
    public enum Operations { Add, Sub, Mul, Div }

    public static Number Add(Number a, Number b)
    {
        //if there is a common denominator
        if (a.getDenominator() == b.getDenominator())
        {
            return new Number(a.getNumerator() + b.getNumerator(), a.getDenominator());
        }

        //if the denominators are multiples of each other
        if (a.getDenominator() % b.getDenominator() == 0 || b.getDenominator() % a.getDenominator() == 0)
        {
            int common;
            int factor;
            int numerator;
            if(a.getDenominator() > b.getDenominator()){
                common = a.getDenominator();
                factor = a.getDenominator() / b.getDenominator();
                numerator = a.getNumerator() + b.getNumerator() * factor;
                
            } else {
                common = b.getDenominator();
                factor = b.getDenominator() / a.getDenominator();
                numerator = a.getNumerator() * factor + b.getNumerator();
            }
            return new Number(numerator,common);
        }

        return new Number(a.getNumerator() * b.getDenominator() + b.getNumerator() * a.getDenominator(), a.getDenominator() * b.getDenominator());

    }

    public static Number Subtract(Number a, Number b){
        //if there is a common denominator
        if (a.getDenominator() == b.getDenominator())
        {
            return new Number(a.getNumerator() - b.getNumerator(), a.getDenominator());
        }

        //if the denominators are multiples of each other
        if (a.getDenominator() % b.getDenominator() == 0 || b.getDenominator() % a.getDenominator() == 0)
        {
            int common;
            int factor;
            int numerator;
            if(a.getDenominator() > b.getDenominator()){
                common = a.getDenominator();
                factor = a.getDenominator() / b.getDenominator();
                numerator = a.getNumerator() - b.getNumerator() * factor;
                
            } else {
                common = b.getDenominator();
                factor = b.getDenominator() / a.getDenominator();
                numerator = a.getNumerator() * factor - b.getNumerator();
            }
            return new Number(numerator,common);
        }

        return new Number(a.getNumerator() * b.getDenominator() - b.getNumerator() * a.getDenominator(), a.getDenominator() * b.getDenominator());
    }

    public static Number Multiply(Number a, Number b){
        return new Number(a.getNumerator() * b.getNumerator(), a.getDenominator() * b.getDenominator());
    }

    public static Number Divide(Number a, Number b){
        if(GameObject.FindObjectOfType<Policy>().isRemainderDivision()){
            Number result;
            result = new Number(a.getNumerator() / b.getNumerator());
            result.setRemainder(a.getNumerator() % b.getNumerator());
            return result;
        }
        return new Number(a.getNumerator() * b.getDenominator(), a.getDenominator() * b.getNumerator());
    }

    public static Operations GenerateOperation(Policy policy){
        if(policy.isIncludeMultiplication() && policy.isIncludeDivision())
            return (Operations)Random.Range(0,4);
        else if(policy.isIncludeMultiplication() && !policy.isIncludeDivision())
            return (Operations)Random.Range(0,3);
        else if(!policy.isIncludeMultiplication() && policy.isIncludeDivision()){
            int random = Random.Range(0,3);
            if(random == 2)
                random = 3;
            return (Operations)random;
        }
        else 
            return (Operations)Random.Range(0,2);
    }

}

