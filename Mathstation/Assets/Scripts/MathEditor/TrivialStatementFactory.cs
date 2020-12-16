using UnityEngine;

public class TrivialStatementFactory
{
    public static TrivialStatement generateStatement(){
        int decide = Random.Range(0,2);
        if(decide==0 || GameObject.FindObjectOfType<Policy>().isSingleOperation())
            return new Number();
        return new OperationStatement();
    }
}
