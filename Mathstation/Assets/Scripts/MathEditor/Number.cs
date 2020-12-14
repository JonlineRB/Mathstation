using System.Collections;
using UnityEngine;

public class Number : TrivialStatement
{
    private int numerator;
    private int denominator = 1;

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
    }

    public Number(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;

        //set smallest possible fraction possible equivalent values

        //case: it's a whole number
        if(this.numerator % this.denominator == 0){
            this.numerator = this.numerator / this.denominator;
            this.denominator = 1;
        }

        //case: common factor
        else if(this.denominator % this.numerator == 0){
            int factor = this.denominator / this.numerator;
            this.numerator = this.numerator / factor;
            this.denominator = this.denominator / factor;
        }
    }

    public Number()
    {
        this.numerator = Random.Range(1, 9);
    }

    public override string ToString()
    {
        if (denominator == 1)
            return this.numerator.ToString();
        return "Frac(" + numerator + "/" + denominator + ")";
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
        return((float)value.getNumerator() / (float)value.getDenominator() == (float)numerator / (float)denominator);
    }
}
