using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{

    [SerializeField]
    private int heightQuotient;
    [SerializeField]
    private int widthQuotient;
    private int height = Screen.height;
    private int width = Screen.width;
    [SerializeField]
    private float horizontalMargin;
    [SerializeField]
    private GameObject fullHeart;
    [SerializeField]
    private GameObject emptyHeart;
    [SerializeField]
    private int maxHearts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHearts(int hearts){
        if(hearts>maxHearts)
            return;

        // int empties = maxHearts - hearts;
        for(int i = 0; i < maxHearts; i++){
            int height = Screen.height;
            int width = Screen.width;
            GameObject heart;
            if(i< hearts)
                heart = GameObject.Instantiate(fullHeart, gameObject.transform);
            else
                heart = GameObject.Instantiate(emptyHeart, gameObject.transform);
            heart.GetComponent<RectTransform>().position = new Vector3(width/widthQuotient + i * horizontalMargin, height - (height / heightQuotient), 0);
        }


    }
}
