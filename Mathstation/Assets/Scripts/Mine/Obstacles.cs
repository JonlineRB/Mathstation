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
    }

    public void CheckEvent(int value){
        if(combined.Count==0)
            return;
        if(value>= combined[0].Item2){
            //triger event
            Debug.Log("Event triggered: " + combined[0].Item1);
            combined.RemoveAt(0);
        }
    }
    
}
