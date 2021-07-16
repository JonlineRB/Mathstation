using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass that overrides OnEnable(), Close() for the Mine Game
public class Dialogue_Mine : Dialogue_Super
{
    public override void OnEnable()
    {
        base.OnEnable();
        GameObject.Find("MineGame").GetComponent<ClickLock>().Lock();
    }

    public override void Close()
    {
        base.Close();
        GameObject.Find("MineGame").GetComponent<ClickLock>().Unlock();
    } 
}
