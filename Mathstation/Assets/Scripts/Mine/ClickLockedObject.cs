using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLockedObject : MonoBehaviour
{
    protected bool IsLocked(){
        return GameObject.Find("MineGame").GetComponent<ClickLock>().isLocked();
    }
}
