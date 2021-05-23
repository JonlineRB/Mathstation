using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpRing : Ring
{
    [SerializeField] private GameObject SpeedUpNotification;
    protected override void ApplyRingEffect(){
        player.GetComponent<ExplorePlayerControls>().SpeedUp();
        //instantiate the speed up notification
        GameObject.Instantiate(SpeedUpNotification,transform.position, Quaternion.identity);
    }    
}
