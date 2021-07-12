using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pans camera to view an object
public class ShowToCamera : MonoBehaviour
{   
    // Interpolation fields
    [SerializeField] private GameObject player;
    [SerializeField] private float duration;
    [SerializeField] private float intermission;
    private Vector3 objectReveal; // Object to which the camera pans

    public void InitPan(Vector3 position){
        objectReveal = position;
        StartCoroutine("PanCamera");
    }
    

    // Camera pan coruitne
    private IEnumerator PanCamera(){
        // Lock player movement (increment)
        player.GetComponent<MoveLock>().IncrementMoveLock();
        // Camera stops following the player
        gameObject.GetComponent<FollowPosition>().SetIsFollownig(false);
        
        float elapsed = 0;
        Vector3 startPosition = transform.position;

        while(elapsed < duration){
            transform.position = new Vector3(Mathf.Lerp(startPosition.x, objectReveal.x, elapsed / duration),
            Mathf.Lerp(startPosition.y, objectReveal.y, elapsed / duration),
            transform.position.z
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(objectReveal.x, objectReveal.y, transform.position.z);

        elapsed = 0;

        yield return new WaitForSeconds(intermission);

        while(elapsed < duration){
            transform.position = new Vector3(Mathf.Lerp(objectReveal.x, player.transform.position.x, elapsed / duration),
            Mathf.Lerp(objectReveal.y, player.transform.position.y, elapsed / duration),
            transform.position.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Camera follows player again, release player lock (decrement)
        gameObject.GetComponent<FollowPosition>().SetIsFollownig(true);
        player.GetComponent<MoveLock>().DecrementMoveLock();
    }
}
