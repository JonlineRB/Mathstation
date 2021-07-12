using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore_Player_Mathcaller : MonoBehaviour, MathCaller
{
    [SerializeField] private GameObject mathEditor; //math editor prefab reference

    //instantiate the math editor interface and sets the object to whom it reports
    public void CallMathEditor()
    {
        //instantiate interface
        GameObject editor = GameObject.Instantiate(mathEditor);
        //set to whom it reports at the end
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    //function called by the editor once math is completed, through the object to which it reports
    public void MathSuccess()
    {
        StartCoroutine(gameObject.GetComponent<PlayerRingInterpolation>().Interpolation_2());
    }
}
