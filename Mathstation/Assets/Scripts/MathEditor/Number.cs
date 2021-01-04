using System.Collections;
using UnityEngine;

public class Number : TrivialStatement
{
    private int numerator;
    private int denominator = 1;
    private int remainder = 0;

    public int getRemainder()
    {
        return this.remainder;
    }

    public void setRemainder(int remainder)
    {
        this.remainder = remainder;
    }


    public int getNumerator()
    {
        return this.numerator;
    }

    public void setNumerator(int numerator)
    {
        this.numerator = numerator;
    }

    public int getDenominator()
    {
        return this.denominator;
    }

    public void setDenominator(int denominator)
    {
        this.denominator = denominator;
    }


    public Number evaluate()
    {
        return this;
    }

    public Number(int numerator)
    {
        this.numerator = numerator;
        this.numerator = this.CatchNegative(numerator, GameObject.FindObjectOfType<Policy>());
    }

    public Number(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;

        Policy policy = GameObject.FindObjectOfType<Policy>();
        this.numerator = this.CatchNegative(numerator, policy);

        //simplify according to policy
        if(policy.isSimplifyFractions()){
            if(this.numerator % this.denominator == 0){
                this.numerator = this.numerator / this.denominator;
                this.denominator = 1;
                // Debug.Log("Ding simplify top down " + this.numerator);
            }
            else if(this.denominator % this.numerator == 0){
                this.denominator = this.denominator / this.numerator;
                this.numerator = 1;
                // Debug.Log("Ding simplify bottom up " + this.denominator);
            }
            
        }
    }

    public Number()
    {
        this.numerator = Random.Range(1, 9);
        Policy policy = GameObject.FindObjectOfType<Policy>();
        if (policy.isIncludeFractions())
            this.denominator = Random.Range(1, 9);

        this.numerator = this.CatchNegative(numerator, GameObject.FindObjectOfType<Policy>());

        //simplify according to policy
        if(policy.isSimplifyFractions()){
            if(this.numerator % this.denominator == 0){
                this.numerator = this.numerator / this.denominator;
                this.denominator = 1;
                Debug.Log("Ding simplify top down " + this.numerator);
            }
            else if(this.denominator % this.numerator == 0){
                this.denominator = this.denominator / this.numerator;
                this.numerator = 1;
                Debug.Log("Ding simplify bottom up " + this.denominator);
            }
            
        }

    }

    public override string ToString()
    {
        if (this.remainder != 0)
            return this.numerator.ToString() + "(" + this.remainder.ToString() + ")";
        else if (denominator == 1)
            return this.numerator.ToString();
        return "F(" + numerator + "/" + denominator + ")";

    }

    private int CatchNegative(int numerator, Policy policy)
    {
        if (!policy.isNegativeValues() && numerator < 0)
        {
            numerator = 0;
        }
        return numerator;
    }

    public bool Compare(int value)
    {
        if (denominator == 0)
            return false;
        if (value == 0 && numerator == 0)
            return true;
        if (denominator == 1)
            return value == numerator;
        return false;
    }

    public bool Compare(Number value)
    {
        if (value.remainder != 0 || this.remainder != 0)
            return (numerator == value.getNumerator() && remainder == value.getRemainder());
        return ((float)value.getNumerator() / (float)value.getDenominator() == (float)numerator / (float)denominator);
    }
}
