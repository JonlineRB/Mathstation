using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private Vector3 translationVector;
    [SerializeField]
    private float velocity;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(translationVector * velocity * Time.deltaTime);
    }

    public void SetTranslateVector(Vector3 translate){
        translationVector = translate;
    }
}
