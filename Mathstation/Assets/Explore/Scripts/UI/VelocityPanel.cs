using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VelocityPanel : MonoBehaviour
{
    //class handles speed updates from the player object

    [SerializeField] private List<GameObject> icons; //List of ring icons
    private int iconIndex;
    [SerializeField] private GameObject textObject; //Text representation of velocity

    public void SpeedUp(string newSpeed){
        //update text value
        textObject.GetComponent<Text>().text = newSpeed; //Update text value
        //update speed ring icon
        icons[iconIndex].SetActive(true);
        //cap the index to the amount of ring available in the game
        iconIndex = Mathf.Min(iconIndex+1,icons.Count);
    }
}
