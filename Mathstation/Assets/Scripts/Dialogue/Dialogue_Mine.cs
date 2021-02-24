using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
