using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{

    public enum Carriables {None, Moon}
    private Carriables carrying;
    // Start is called before the first frame update
    void Start()
    {
        carrying = Carriables.None;
    }

    public void SetCarrying(Carriables value){
        carrying = value;
    }

    public Carriables GetCarrying(){
        return carrying;
    }

    public bool IsCarrying(){
        return carrying!=Carriables.None;
    }
}
