using UnityEngine;

// Factory class for Trivial statement
public class TrivialStatementFactory
{
    // Either returns Number or operation statement
    public static TrivialStatement generateStatement(){
        int decide = Random.Range(0,2);
        if(decide==0 || GameObject.FindObjectOfType<Policy>().isSingleOperation())
            return new Number();
        return new OperationStatement();
    }
}
