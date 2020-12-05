using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction
{
    private int numerator;
    private int denominator = 1;

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if(denominator == 0)
            return;
        this.denominator = denominator;
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
        if(!(denominator == 0))
            this.denominator = denominator;
    }

    public float evaluate()
    {
        return (float)numerator/(float)denominator;
    }

}
