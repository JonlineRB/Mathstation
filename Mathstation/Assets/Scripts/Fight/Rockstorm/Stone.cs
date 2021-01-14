using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    [SerializeField]
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        int deg = Random.Range(0,359);
        SetVelocity(new Vector2(Mathf.Sin(deg),Mathf.Cos(deg))* velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVelocity(Vector2 velocity){
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
