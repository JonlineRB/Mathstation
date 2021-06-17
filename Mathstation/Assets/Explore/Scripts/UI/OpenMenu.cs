using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public void CallMenu(){
        gameObject.SetActive(true);
        gameObject.GetComponent<TimeControl>().StopTime();
        GameObject.Find("Player").GetComponent<MoveLock>().IncrementMoveLock();
    }
}
