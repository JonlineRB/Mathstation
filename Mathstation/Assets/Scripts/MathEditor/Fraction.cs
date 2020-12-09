using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction
{
    private int numerator{get; set;}
    private int denominator{get; set;}

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if(denominator == 0){
            this.denominator = 1;
            return;
        }
            
        this.denominator = denominator;
    }

    public float evaluate()
    {
        return (float)numerator/(float)denominator;
    }

    public new string ToString(){
        return "Frac("+this.numerator+","+this.denominator+")";
    }

}
