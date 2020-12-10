using UnityEngine;

public class TrivialStatementFactory
{
    public static TrivialStatement generateStatement(){
        int decide = Random.Range(0,2);
        // decide = 0;//////////////////////////////////////
        if(decide==0)
            return new Number(Random.Range(1,9),Random.Range(1,9));
        return new OperationStatement();
    }
}
