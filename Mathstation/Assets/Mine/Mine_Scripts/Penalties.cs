using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalties : MonoBehaviour
{
    [SerializeField]
    private List<MineGameEvent.EventType> entries;

    public void Add(MineGameEvent.EventType eventLog){
        entries.Add(eventLog);
    }

    public new string ToString(){
        string result = "";
        foreach(MineGameEvent.EventType entry in entries){
            result += entry.ToString();
            result +="\n";
        }
        return result;
    }
}
