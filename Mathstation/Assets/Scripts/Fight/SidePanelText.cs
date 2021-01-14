using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanelText : MonoBehaviour
{
    [SerializeField]
    private GameObject fightGame;
    private int displayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayText = (int)fightGame.GetComponent<FightMaster>().energy;
        gameObject.GetComponent<Text>().text = displayText + "%";
    }
}
