using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployButtonListener : MonoBehaviour
{
    [SerializeField]
    private GameObject resourceContainer;
    void Update()
    {
        if(resourceContainer.GetComponent<Resource>().isFullResources())
            gameObject.GetComponent<Button>().interactable = true;
        else
            gameObject.GetComponent<Button>().interactable = false;
    }
}
