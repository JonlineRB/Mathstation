using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetMarker : MonoBehaviour
{
    [SerializeField]
    private GameObject targetMarker;
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            //if player movement is locked, don't do anything
            if(player.GetComponent<MoveLock>().IsMoveLock())
                return;
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
