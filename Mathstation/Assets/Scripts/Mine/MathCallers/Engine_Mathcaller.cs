using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Mathcaller : Mine_Super_Mathcaller
{
    public override void MathSuccess()
    {
        base.MathSuccess();
        GameObject.Find("MineGame").GetComponent<Engine>().DeployEngine();
    }
}
