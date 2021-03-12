using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] protected float interpolationDistance;
    [SerializeField] protected GameObject moveMarker;
    [SerializeField] protected float duration;
    [SerializeField] protected float size;
    [SerializeField] protected float windUp;
    [SerializeField] protected GameObject lowerPart;
    protected GameObject player;
    public void OnTriggerEnter2D(Collider2D other){
        moveMarker.SetActive(false);
        other.GetComponent<Fuel>().SetConsuming(false);
        player = other.gameObject;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //interpolate player into a specified position
        other.GetComponent<PlayerRingInterpolation>().Init1stInterpolation(transform.position - new Vector3(0, interpolationDistance, 0), gameObject);
    }

    public IEnumerator Consume(){
        //apply the ring's effect to player here
        ApplyRingEffect();
        //windUp to delay the consumption effect
        yield return new WaitForSeconds(windUp);
        float elapsed= 0;
        Vector3 currentSize = transform.localScale;
        Vector3 endSize = currentSize * size;

        Color currentColor = transform.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color(255f,255f,255f,0);


        while(elapsed < duration){
            transform.localScale = Vector3.Lerp(currentSize, endSize, elapsed / duration);
            transform.GetComponent<SpriteRenderer>().color = Color.Lerp(currentColor, endColor, elapsed / duration);
            lowerPart.GetComponent<SpriteRenderer>().color = Color.Lerp(currentColor, endColor, elapsed / duration);

            elapsed += Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
    }

    protected virtual void ApplyRingEffect(){}
}
