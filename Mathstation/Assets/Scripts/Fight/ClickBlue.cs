using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBlue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlueClicked(){
        Debug.Log("Blue Click");
        GameObject.Find("FightGame").GetComponent<FightMaster>().callEditor();
    }
}
