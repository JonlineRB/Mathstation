using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class overrides Dialogue_Super.Close() for a fight game specific implementation
public class Dialogue_1 : Dialogue_Super
{

    public override void Close(){
        GameObject fightGame = GameObject.Find("FightGame");
        fightGame.GetComponent<FightMaster>().ActivateOpponent();
        fightGame.GetComponent<FightMaster>().releasePauseCharging();
        base.Close();
    }
}
