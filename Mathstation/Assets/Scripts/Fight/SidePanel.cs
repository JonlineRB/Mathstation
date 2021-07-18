using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI management class
public class SidePanel : MonoBehaviour
{
    // Charge light bulb object sprite references
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite charged;

    // Methods swap the sprite
    public void toCharged(){
        gameObject.GetComponent<Image>().sprite = charged;
    }

    public void toIdle(){
        gameObject.GetComponent<Image>().sprite = idle;
    }
}
