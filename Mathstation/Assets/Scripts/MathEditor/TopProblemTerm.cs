using UnityEngine;

public class TopProblemTerm : ProblemTerm
{

    private TrivialStatement operand_a{ get; set;}
    private MathOperations.Operations operation{ get; set;}
    private TrivialStatement operand_b{ get; set;}
    public TopProblemTerm(){
        this.operand_a = TrivialStatementFactory.generateStatement();
        this.operand_b = TrivialStatementFactory.generateStatement();
        this.operation = (MathOperations.Operations)Random.Range(0,4);
    }

    public override int evaluate(){
        return base.evaluate(this.operand_a, this.operand_b, this.operation);
    }

    public override string ToString()
    {
        return operand_a.ToString() + " " + operation.ToString() + " " + operand_b.ToString();
    }
}
