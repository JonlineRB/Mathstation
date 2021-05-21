using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore_Player_Mathcaller : MonoBehaviour, MathCaller
{
    [SerializeField] private GameObject mathEditor;

    public void CallMathEditor()
    {
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    public void MathSuccess()
    {
        //replace this with a call to the object that initiated the math sequence
        StartCoroutine(gameObject.GetComponent<PlayerRingInterpolation>().Interpolation_2());
    }
}
