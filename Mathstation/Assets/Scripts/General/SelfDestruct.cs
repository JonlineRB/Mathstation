using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField]
    private float selfDestructionTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitSelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InitSelfDestruct(){
        yield return new WaitForSeconds(selfDestructionTimer);
        GameObject.Destroy(gameObject);
    }
}
