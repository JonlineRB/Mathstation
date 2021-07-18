using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the stone effect sprite
public class Stone : MonoBehaviour
{

    [SerializeField]
    private float velocity;
    void Start()
    {
        // Generate random direction
        int deg = Random.Range(0,359);
        SetVelocity(new Vector2(Mathf.Sin(deg),Mathf.Cos(deg))* velocity);
    }

    public void SetVelocity(Vector2 velocity){
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
