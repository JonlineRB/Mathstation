using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Time control script
public class TimeControl : MonoBehaviour
{
    public void StopTime(){
        Time.timeScale = 0;
    }

    public void ResumeTime(){
        Time.timeScale = 1;
    }
}
