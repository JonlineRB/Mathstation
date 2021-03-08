using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private GameObject following;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(following.transform.position.x, following.transform.position.y, transform.position.z);
    }
}
