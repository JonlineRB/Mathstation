using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ClickLockedObject
{
    [SerializeField]
    private GameObject engine;

    [SerializeField]
    private Sprite engineOn;
        [SerializeField]
    private Sprite engineOff;

    void OnMouseDown(){
        if(IsLocked())
            return;
        engine.GetComponent<Engine>().StartStopEngine();
    }

    public void setSprite(bool isOn){
        if(isOn)
            gameObject.GetComponent<SpriteRenderer>().sprite = engineOn;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = engineOff;
    }
}
