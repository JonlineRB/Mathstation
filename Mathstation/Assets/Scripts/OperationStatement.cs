using UnityEngine;

public class OperationStatement :  ProblemTerm, TrivialStatement
{
    private Number operand_a{ get; set;}
    private MathOperations.Operations operation{ get; set;}
    private Number operand_b{ get; set;}

    public OperationStatement(){
        this.operand_a = new Number();
        this.operand_b = new Number();
        this.operation = (MathOperations.Operations)Random.Range(0,4);
    }

    public override int evaluate(){
        return base.evaluate(this.operand_a, this.operand_b, this.operation);
    }

    public override string ToString()
    {
        return "(" + operand_a.ToString() + " " + operation.ToString() + " " + operand_b.ToString() + ")";
    }
}
