using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchJourneyReport : MonoBehaviour
{
    void OnEnable(){
        string result = GameObject.Find("MineGame").GetComponent<Penalties>().ToString();
        if(result == ""){
            result = "Flawless journey. Well done!";
        }
        gameObject.GetComponent<Text>().text = result;
    }
}
