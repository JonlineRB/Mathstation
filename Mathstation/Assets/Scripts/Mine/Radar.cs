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

    private List<GameObject> blips = new List<GameObject>();

    private int journey;

    //put the sprites on the radar
    void OnEnable(){
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
            GameObject instancee = null;
            switch (entry.Item1){
            case MineGameEvent.EventType.Blockade:
                instancee = blockade;
                break;
            case MineGameEvent.EventType.Pirates:
                instancee = pirates;
                break;
            }
            GameObject blip = GameObject.Instantiate(instancee, transform);
            blip.transform.Translate(new Vector3(((float)entry.Item2 - (float)journey) / radarRange * 120 + 50,0,0)); //max range is 170, min is 50
            blips.Add(blip);
        }
    }
    
    void OnDisable(){
        foreach(GameObject blip in blips)
            GameObject.Destroy(blip);
        blips = new List<GameObject>();
    }
}
