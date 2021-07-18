using UnityEngine;

// Top Problem term. Has two Trivial statement fields and a binary operation
public class TopProblemTerm : ProblemTerm
{
    private TrivialStatement operand_a{ get; set;}
    private MathOperations.Operations operation{ get; set;}
    private TrivialStatement operand_b{ get; set;}
    public TopProblemTerm(){
        this.operand_a = TrivialStatementFactory.generateStatement();
        this.operand_b = TrivialStatementFactory.generateStatement();
        Policy policy = GameObject.FindObjectOfType<Policy>();
        this.operation = MathOperations.GenerateOperation(policy);
    }

    public override Number evaluate(){
        return base.evaluate(this.operand_a, this.operand_b, this.operation);
    }

    public override string ToString()
    {
        return operand_a.ToString() + " " + operation.ToString() + " " + operand_b.ToString();
    }
}
