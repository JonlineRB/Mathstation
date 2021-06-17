using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public void UncallMenu(){
        gameObject.GetComponent<TimeControl>().ResumeTime();
        GameObject player = GameObject.Find("Player");
        player.GetComponent<MoveLock>().DecrementMoveLock();
        GameObject.Find("TargetMarker").SetActive(false);
        player.GetComponent<Fuel>().SetConsuming(false);
        gameObject.SetActive(false);
    }
}
