
public class Problem
{
    private ProblemTerm statement{get; set;}
    private Number solution;

    public Number getSolution()
    {
        return this.solution;
    }

    public void setSolution(Number solution)
    {
        this.solution = solution;
    }


    public Problem(){
        this.statement = new TopProblemTerm();
        this.solution = this.statement.evaluate();
    }

    public string ToString(bool includeSolution)
    {
        string result = this.statement.ToString();
        if(includeSolution)
            result += " = " + this.solution;
        return result;
    }
}
