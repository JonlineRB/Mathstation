using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amp : MonoBehaviour
{
    public void Attack(){
        gameObject.GetComponent<FlashColor>().Flash();
    }
}
