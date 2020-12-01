using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem
{
    private ProblemTerm statement;
    private int solution;

    public Problem(){
        this.statement = new ProblemTerm();
        this.solution = this.statement.evaluate();
    }

    public string toString()
    {
        return "The problem statement is " + this.statement.toString() + "\nand the solution is " + this.solution;
    }
}
