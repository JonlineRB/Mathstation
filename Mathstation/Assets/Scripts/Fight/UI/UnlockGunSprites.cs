using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGunSprites : MonoBehaviour
{

    void OnDisable(){
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Unlock();
    }

    void OnDestroy(){
        GameObject.Find("GunSpriteManager").GetComponent<GunSprites>().Unlock();
    }
}
