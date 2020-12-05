using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{

    public Sprite[] sprites;

    public GameObject symbol;
    public GameObject numberSymbolContainer;

    public int startXPosition;
    public int stepSize;
    public int digitStepSize;
    private int stepCount = 0;
    
    //set the sprites
    public void SetSprites(string problem){
        string[] tokens = problem.Split(' ');
        foreach(string token in tokens){
            int spriteIndex = -1;
            switch(token){
                // case "0":
                //     spriteIndex = 0;
                //     break;
                // case "1":
                //     spriteIndex = 1;
                //     break;
                // case "2":
                //     spriteIndex = 2;
                //     break;
                // case "3":
                //     spriteIndex = 3;
                //     break;
                // case "4":
                //     spriteIndex = 4;
                //     break;
                // case "5":
                //     spriteIndex = 5;
                //     break;
                // case "6":
                //     spriteIndex = 6;
                //     break;
                // case "7":
                //     spriteIndex = 7;
                //     break;
                // case "8":
                //     spriteIndex = 8;
                //     break;
                // case "9":
                //     spriteIndex = 9;
                //     break;
                case "Add":
                    spriteIndex = 10;
                    break;
                case "Sub":
                    spriteIndex = 11;
                    break;
                case "Mul":
                    spriteIndex = 12;
                    break;
                case "Div":
                    spriteIndex = 13;
                    break;
                case "(":
                    spriteIndex = 14;
                    break;
                case ")":
                    spriteIndex = 15;
                    break;
                case "=":
                    spriteIndex = 16;
                    break;
                default:
                    spriteIndex = -1;
                    break;
            }
            if(spriteIndex!=-1){
                GameObject symbol = GameObject.Instantiate(this.symbol, transform.position + new Vector3(startXPosition + stepSize * stepCount++,0,0), Quaternion.identity, transform);
                symbol.GetComponent<Image>().sprite = sprites[spriteIndex];
                continue;
            }

            //iterate over chars of string, create empty object with symbols for each char
            GameObject numberSymbolContainer = GameObject.Instantiate(this.numberSymbolContainer, transform.position + new Vector3(startXPosition + stepSize * stepCount++,0,0), Quaternion.identity, transform);
            // NumberSymbolContainer.name = "NumberSymbolContainer";
            // NumberSymbolContainer.GetComponent<Image>().enabled = false;

            int digitCounter = 0;
            foreach(char c in token){
                GameObject symbol = GameObject.Instantiate(this.symbol,
                numberSymbolContainer.transform.position + new Vector3(digitStepSize * digitCounter++,0,0),
                 Quaternion.identity, numberSymbolContainer.transform);
                if(c == '-')
                    spriteIndex = 11;
                else
                    spriteIndex = (int)char.GetNumericValue(c);
                symbol.GetComponent<Image>().sprite = sprites[spriteIndex];
            }
            
        }
    }
}
