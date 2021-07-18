using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script unlocks gun sprites when the attached game object is disabled or destoyed
public class UnlockGunSprites : MonoBehaviour
{
    void OnDisable(){
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Unlock();
    }

    void OnDestroy(){
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Unlock();
    }
}
