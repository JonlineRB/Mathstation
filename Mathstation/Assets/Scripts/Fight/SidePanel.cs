using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanel : MonoBehaviour
{
    [SerializeField]
    private Sprite idle;
    [SerializeField]
    private Sprite charged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toCharged(){
        gameObject.GetComponent<Image>().sprite = charged;
    }

    public void toIdle(){
        gameObject.GetComponent<Image>().sprite = idle;
    }
}
