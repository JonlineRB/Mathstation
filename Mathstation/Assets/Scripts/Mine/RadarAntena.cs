using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarAntena : MonoBehaviour
{
    [SerializeField]
    private GameObject popup;

    void OnMouseDown(){
        if(GameObject.Find("MineGame").GetComponent<ClickLock>().isLocked())
            return;
        popup.SetActive(true);
        GameObject.Find("MineGame").GetComponent<ClickLock>().Lock();
    }
}
