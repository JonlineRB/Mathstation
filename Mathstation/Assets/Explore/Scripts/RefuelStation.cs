using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Refuel Station class
public class RefuelStation : Artifact_Super
{
    [SerializeField] private GameObject FuelNotification; //Floating notification when the player refuels

    // Once activated, the artifact restores the players fuel to full.
    // Invoked when the player enters it's collider
    protected override void Action()
    {
        base.Action();
        //refeul the player
        GameObject.Find("Player").GetComponent<Fuel>().ResetFuel();
        background.GetComponent<ConditionFade>().InitFadeIn();
        GameObject.Instantiate(FuelNotification, transform.position, Quaternion.identity);
    }

    // Exit collider VFX
    protected override void Exit()
    {
        background.GetComponent<ConditionFade>().InitFadeOut();
    }
}
