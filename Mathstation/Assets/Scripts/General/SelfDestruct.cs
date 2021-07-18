using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Self destruct script, destruction coroutine called on Start()
// Used for prefabs with a limited lifetime
public class SelfDestruct : MonoBehaviour
{

    [SerializeField]
    private float selfDestructionTimer;
    
    void Start()
    {
        StartCoroutine(InitSelfDestruct());
    }

    IEnumerator InitSelfDestruct(){
        yield return new WaitForSeconds(selfDestructionTimer);
        GameObject.Destroy(gameObject);
    }
}
