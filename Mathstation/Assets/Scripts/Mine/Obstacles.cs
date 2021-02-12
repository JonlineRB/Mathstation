using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private MineGameEvent.EventType[] events;
    [SerializeField]
    private int[] occourences;

    private  List<(MineGameEvent.EventType, int, bool)> combined = new List<(MineGameEvent.EventType, int, bool)>();

    void Start(){
        System.Array.Sort(occourences);
        for(int i = 0; i < occourences.Length && i < events.Length; i++){
            combined.Add((events[i], occourences[i], true));
        }

        //testing
        Debug.Log("combined:");
        foreach((MineGameEvent.EventType, int, bool) entry in combined){
            Debug.Log(entry.Item1 + ", " + entry.Item2 + ", " + entry.Item3);
        }
    }
    
}
