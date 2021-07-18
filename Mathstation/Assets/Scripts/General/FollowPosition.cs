using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script makes the object follow a specified object
public class FollowPosition : MonoBehaviour
{
    [SerializeField] private GameObject following; //Reference to object to follow
    private bool isFollowing = true;

    // Update is called once per frame
    void Update()
    {
        if(!following || !isFollowing)
            return;
        transform.position = new Vector3(following.transform.position.x, following.transform.position.y, transform.position.z);
    }

    public void SetFollowing(GameObject followObject){
        following = followObject;
    }

    public void SetIsFollownig(bool value){
        isFollowing = value;
    }
}