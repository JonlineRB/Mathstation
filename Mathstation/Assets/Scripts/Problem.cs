
public class Problem
{
    private ProblemTerm statement;
    private int solution;

    public Problem(){
        this.statement = new TopProblemTerm();
        this.solution = this.statement.evaluate();
    }

    public override string ToString()
    {
        return "The problem statement is " + this.statement.ToString() + "\nand the solution is " + this.solution;
    }
}
