
public class Problem
{
    private ProblemTerm statement{get; set;}
    private int solution{get; set;}

    public Problem(){
        this.statement = new TopProblemTerm();
        this.solution = this.statement.evaluate();
    }

    public override string ToString()
    {
        return this.statement.ToString() + " = " + this.solution;
    }
}
