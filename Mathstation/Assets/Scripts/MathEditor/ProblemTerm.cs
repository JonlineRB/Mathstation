
public class ProblemTerm
{
    public int evaluate(TrivialStatement a, TrivialStatement b, MathOperations.Operations op){
        switch(op)
        {
        case MathOperations.Operations.Add:
            return a.evaluate() + b.evaluate();
        case MathOperations.Operations.Sub:
            return a.evaluate() - b.evaluate();
        case MathOperations.Operations.Mul:
            return a.evaluate() * b.evaluate();
        case MathOperations.Operations.Div:
            return a.evaluate() / b.evaluate();
        }
        return 0;
    }
    public virtual int evaluate(){return 0;}

}
