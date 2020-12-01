using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemTerm
{
    private int operand_a;
    private MathOperations.Operations operation;
    private int operand_b;

    public int getOperand_a()
    {
        return this.operand_a;
    }

    public void setOperand_a(int operand_a)
    {
        this.operand_a = operand_a;
    }

    public MathOperations.Operations getOperation()
    {
        return this.operation;
    }

    public void setOperation(MathOperations.Operations operation)
    {
        this.operation = operation;
    }

    public int getOperand_b()
    {
        return this.operand_b;
    }

    public void setOperand_b(int operand_b)
    {
        this.operand_b = operand_b;
    }

    public int evaluate(){
        switch(this.operation)
        {
        case MathOperations.Operations.Add:
            return operand_a + operand_b;
        case MathOperations.Operations.Sub:
            return operand_a - operand_b;
        case MathOperations.Operations.Mul:
            return operand_a * operand_b;
        case MathOperations.Operations.Div:
            return operand_a / operand_b;
        }
        return 0;
    }

    public ProblemTerm(){
        this.operand_a = Random.Range(1, 10);
        this.operand_b = Random.Range(1, 10);
        this.operation = (MathOperations.Operations)Random.Range(0,4);
    }

    public string toString()
    {
        return operand_a.ToString() + " " + this.operation + " "  + operand_b.ToString();
    }

}
