using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SpeedUp ring subclass
public class SpeedUpRing : Ring
{
    //Reference for the speed up text notification, floats once upgrade is applied
    [SerializeField] private GameObject SpeedUpNotification;
    //Overrides to upgrade the player's speed
    protected override void ApplyRingEffect(){
        player.GetComponent<ExplorePlayerControls>().SpeedUp();
        //Instantiate the speed up notification
        GameObject.Instantiate(SpeedUpNotification,transform.position, Quaternion.identity);
    }    
}
