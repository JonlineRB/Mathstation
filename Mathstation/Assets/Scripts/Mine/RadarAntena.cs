using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarAntena : ClickLockedObject
{
    [SerializeField]
    private GameObject popup;

    void OnMouseDown(){
        if(IsLocked())
            return;
        popup.SetActive(true);
        GameObject.Find("MineGame").GetComponent<ClickLock>().Lock();
    }
}
