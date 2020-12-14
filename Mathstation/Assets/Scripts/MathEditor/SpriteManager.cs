using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private Dictionary<string,int> spriteIndex = new Dictionary<string, int>();
    private Problem problem;

    public Problem getProblem()
    {
        return this.problem;
    }

    public void setProblem(Problem problem)
    {
        this.problem = problem;
        //initialize sprites here
    }

    void Awake(){
        //init here
        initSpriteIndexDict();
    }


    private void initSpriteIndexDict(){
        spriteIndex.Add("0",0);
        spriteIndex.Add("1",1);
        spriteIndex.Add("2",2);
        spriteIndex.Add("3",3);
        spriteIndex.Add("4",4);
        spriteIndex.Add("5",5);
        spriteIndex.Add("6",6);
        spriteIndex.Add("7",7);
        spriteIndex.Add("8",8);
        spriteIndex.Add("9",9);
        spriteIndex.Add("Add",10);
        spriteIndex.Add("Sub",11);
        spriteIndex.Add("Mul",12);
        spriteIndex.Add("Div",13);
        spriteIndex.Add("=",14);
        spriteIndex.Add("(",15);
        spriteIndex.Add(")",16);
        spriteIndex.Add("-",11);
    }

    public Sprite GetSprite(string input){
        return sprites[spriteIndex[input]];
    }
}
