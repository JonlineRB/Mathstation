using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelStation : Artifact_Super
{
    [SerializeField] private GameObject FuelNotification;
    protected override void Action()
    {
        base.Action();
        //refeul the player
        GameObject.Find("Player").GetComponent<Fuel>().ResetFuel();
        background.GetComponent<ConditionFade>().InitFadeIn();
        GameObject.Instantiate(FuelNotification, transform.position, Quaternion.identity);
    }

    protected override void Exit()
    {
        background.GetComponent<ConditionFade>().InitFadeOut();
    }
}
