using System.Collections;
using UnityEngine;

public class Number : TrivialStatement
{
    private int value{ get; set; }

    public int evaluate(){
        return value;
    }

    public Number(int value){
        this.value = value;
    }

    public Number(){
        this.value = Random.Range(1,9);
    }

    public override string  ToString(){
        return this.value.ToString();
    }
}
