
// Math problem class
public class Problem
{
    private ProblemTerm problemPart;

    public ProblemTerm getProblemPart()
    {
        return this.problemPart;
    }

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
        this.problemPart = new TopProblemTerm();
        this.solution = this.problemPart.evaluate();
    }

    public string ToString(bool includeSolution)
    {
        string result = this.problemPart.ToString();
        if(includeSolution)
            result += " = " + this.solution;
        return result;
    }
}
