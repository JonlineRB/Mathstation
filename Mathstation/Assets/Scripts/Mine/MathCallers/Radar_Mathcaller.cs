using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Mathcaller : Mine_Super_Mathcaller
{
    [SerializeField]
    private bool callTutorialLine;
    [SerializeField]
    private GameObject tutorialLine;
    public override void MathSuccess()
    {
        base.MathSuccess();
        if(callTutorialLine)
            tutorialLine.SetActive(true);
    }
}
