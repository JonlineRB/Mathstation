using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetMarker : MonoBehaviour
{
    [SerializeField]
    private GameObject targetMarker;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Vector2 mouseScreenPosition = Input.mousePosition;
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(mouseScreenPosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo)){
                //move the gameobject here
                targetMarker.transform.position = hitInfo.point;
                targetMarker.SetActive(true);
            }
        }
    }
}
