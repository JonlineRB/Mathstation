using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationStatement :  ProblemTerm, TrivialStatement
{
    private Number operand_a{ get; set;}
    private MathOperations.Operations operation{ get; set;}
    private Number operand_b{ get; set;}

    public OperationStatement(){
        this.operand_a = new Number();
        this.operand_b = new Number();
        Policy policy = GameObject.FindObjectOfType<Policy>();
        this.operation = MathOperations.GenerateOperation(policy);
    }

    public override Number evaluate(){
        return base.evaluate(this.operand_a, this.operand_b, this.operation);
    }

    public override string ToString()
    {
        return "( " + operand_a.ToString() + " " + operation.ToString() + " " + operand_b.ToString() + " )";
    }
}
