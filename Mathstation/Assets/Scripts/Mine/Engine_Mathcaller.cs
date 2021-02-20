using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Mathcaller : MonoBehaviour, MathCaller
{

    [SerializeField]
    private GameObject mathEditor;
    [SerializeField]
    private GameObject successObject;

    public void CallMathEditor(){
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
        Time.timeScale=0;
        GameObject.Find("MineGame").GetComponent<ClickLock>().Lock();
    }

    public void MathSuccess()
    {
        Time.timeScale=1;
        GameObject.Find("MineGame").GetComponent<ClickLock>().Unlock();
        successObject.SetActive(true);
        GameObject.Find("MineGame").GetComponent<Engine>().DeployEngine();
        gameObject.SetActive(false);
    }
}
