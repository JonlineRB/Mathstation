using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handles artifact interpolation (Objects that are not consumed by the player after solving math)
public class ArtifactInterpolation : MonoBehaviour
{

    [SerializeField] private float duration; //Duration of interpolation
    //Initialize the interpolation, calls coroutine
    public void InitInterpolation(Vector3 position){
        //Disable the movement marker of the player
        GameObject moveMarker = GameObject.Find("TargetMarker");
        if(moveMarker)
            moveMarker.SetActive(false);
        gameObject.GetComponent<Fuel>().SetConsuming(false); //Stop fuel consumption
        gameObject.GetComponent<MoveLock>().IncrementMoveLock(); //Lock player movement (increment)
        gameObject.GetComponent<Reset>().IncrementLockReset(); //Lock player reset (increment)
        StartCoroutine(Interpolate(position)); //Call coroutine with target position parameter
    }

    //Interpolation
    // @ position - the target position (Vector3) for the interpolation.
    // Player is placed there upon completion
    private IEnumerator Interpolate(Vector3 position){
        float elapsed = 0; //Time counter
        Vector3 ogPosition = transform.position; //Store reference to original position
        Quaternion ogRotation = transform.rotation; //Store reference to original rotation

        //Interpolation loop
        while(elapsed <= duration){            
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(ogPosition, position, elapsed / duration);
            transform.rotation = Quaternion.Lerp(ogRotation, Quaternion.identity, elapsed / duration);
            yield return null;
        }

        //Upon completion:
        gameObject.GetComponent<MoveLock>().DecrementMoveLock(); //Release player movement lock (decrement)
        gameObject.GetComponent<Reset>().DecrementLockReset(); //Release player reset lock (decrement)
        transform.position = position; //Set the player's position to the target position
    }
}
