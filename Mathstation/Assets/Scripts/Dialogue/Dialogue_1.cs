using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_1 : Dialogue_Super
{

    public override void Close(){
        GameObject fightGame = GameObject.Find("FightGame");
        fightGame.GetComponent<FightMaster>().ActivateOpponent();
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        base.Close();
    }
}
