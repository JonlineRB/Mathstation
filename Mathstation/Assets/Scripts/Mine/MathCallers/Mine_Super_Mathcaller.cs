using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine_Super_Mathcaller : MonoBehaviour, MathCaller
{
    [SerializeField]
    private GameObject mathEditor;
    [SerializeField]
    private GameObject successObject;
    public virtual void CallMathEditor(){
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
        Time.timeScale=0;
        GameObject.Find("MineGame").GetComponent<ClickLock>().Lock();
    }

    public virtual void MathSuccess(){
        Time.timeScale=1;
        GameObject.Find("MineGame").GetComponent<ClickLock>().Unlock();
        successObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
