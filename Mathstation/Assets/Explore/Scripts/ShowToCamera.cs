using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowToCamera : MonoBehaviour
{   
    [SerializeField] private GameObject player;
    [SerializeField] private float duration;
    [SerializeField] private float intermission;
    private Vector3 objectReveal;

    public void InitPan(Vector3 position){
        objectReveal = position;
        StartCoroutine("PanCamera");
    }
    

    private IEnumerator PanCamera(){
        player.GetComponent<MoveLock>().setMoveLock(true);
        gameObject.GetComponent<FollowPosition>().SetIsFollownig(false);
        
        float elapsed = 0;
        Vector3 startPosition = transform.position;

        while(elapsed < duration){
            // transform.position = Vector3.Lerp(startPosition, objectReveal, elapsed / duration);
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
            // transform.position = Vector3.Lerp(objectReveal, startPosition, elapsed / duration);
            transform.position = new Vector3(Mathf.Lerp(objectReveal.x, player.transform.position.x, elapsed / duration),
            Mathf.Lerp(objectReveal.y, player.transform.position.y, elapsed / duration),
            transform.position.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        gameObject.GetComponent<FollowPosition>().SetIsFollownig(true);
        player.GetComponent<MoveLock>().setMoveLock(false);
    }
}
