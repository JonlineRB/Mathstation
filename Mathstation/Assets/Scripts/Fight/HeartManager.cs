using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHearts(int value){
        for(int i = 0; i < hearts.Length; i++){
            if(i<value)
                hearts[i].GetComponent<Image>().sprite = fullHeart;
            else
                hearts[i].GetComponent<Image>().sprite = emptyHeart;
        }
    }

    public void SetMaxHearts(int value){
        for(int i = 0; i < hearts.Length; i++){
            if(i >= value)
                hearts[i].SetActive(false);
        }
    }
}
