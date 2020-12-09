
public class Problem
{
    private ProblemTerm statement{get; set;}
    private int solution;

    public int getSolution()
    {
        return this.solution;
    }

    public void setSolution(int solution)
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
