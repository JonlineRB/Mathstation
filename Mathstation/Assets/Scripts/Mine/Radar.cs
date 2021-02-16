using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    //general fields
    [SerializeField]
    private int radarRange;

    //sprites for symbols on radar view
    [SerializeField]
    private GameObject pirates;
    [SerializeField]
    private GameObject blockade;

    private int journey;

    //put the sprites on the radar
    void OnEnable(){
        Debug.Log("DING");
        //get sprite status, journey
        GameObject mineGame = GameObject.Find("MineGame");
        journey = mineGame.GetComponent<Engine>().getJourney();

        //get the events
        List<(MineGameEvent.EventType, int)> events = mineGame.GetComponent<Obstacles>().getEvents();

        //for each event in the list, check if it's within range
        foreach((MineGameEvent.EventType, int) entry in events){
            if(!(entry.Item2 - journey <= radarRange))
                continue;
            //if it's in range, instantiate prefab (sprite)
            Debug.Log("event on radar: " + entry.Item1.ToString());
        }
    }
}
