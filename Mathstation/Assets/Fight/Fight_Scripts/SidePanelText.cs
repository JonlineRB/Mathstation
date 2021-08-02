using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI Energy value text management script
public class SidePanelText : MonoBehaviour
{
    [SerializeField]
    private GameObject fightGame;
    private int displayText;
    
    void Update()
    {
        displayText = (int)fightGame.GetComponent<FightMaster>().energy;
        gameObject.GetComponent<Text>().text = displayText + "%";
    }
}
