using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProblemTerm
{
    public Number evaluate(TrivialStatement a, TrivialStatement b, MathOperations.Operations op){
        switch(op)
        {
        case MathOperations.Operations.Add:
            return MathOperations.Add(a.evaluate(),b.evaluate());
        case MathOperations.Operations.Sub:
            return MathOperations.Subtract(a.evaluate(), b.evaluate());
        case MathOperations.Operations.Mul:
            return MathOperations.Multiply(a.evaluate(), b.evaluate());
        case MathOperations.Operations.Div:
            return MathOperations.Divide(a.evaluate(), b.evaluate());
        }
        return new Number(0);
    }
    public virtual Number evaluate(){return new Number(0);}

}
