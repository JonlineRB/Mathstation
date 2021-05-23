using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactInterpolation : MonoBehaviour
{

    [SerializeField] private float duration;
    public void InitInterpolation(Vector3 position){
        GameObject moveMarker = GameObject.Find("TargetMarker");
        if(moveMarker)
            moveMarker.SetActive(false);
        gameObject.GetComponent<Fuel>().SetConsuming(false);
        gameObject.GetComponent<MoveLock>().setMoveLock(true);
        gameObject.GetComponent<Reset>().LockReset();
        StartCoroutine(Interpolate(position));
        
        
    }

    private IEnumerator Interpolate(Vector3 position){
        float elapsed = 0;
        Vector3 ogPosition = transform.position;
        Quaternion ogRotation = transform.rotation;

        while(elapsed <= duration){            
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(ogPosition, position, elapsed / duration);
            transform.rotation = Quaternion.Lerp(ogRotation, Quaternion.identity, elapsed / duration);
            yield return null;
        }

        transform.position = position;
    }
}
