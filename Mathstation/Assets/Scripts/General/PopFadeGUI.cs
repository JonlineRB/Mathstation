using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI effect that scales an element up and fades it out
public class PopFadeGUI : MonoBehaviour
{
    [SerializeField]
    private float growFactor;
    [SerializeField]
    private float duration;
    [SerializeField]
    private Color targetColor;
    private Vector3 ogSize;
    private Color ogColor;

    public void initPopFade(){
        ogSize = transform.localScale;
        ogColor = gameObject.GetComponent<Image>().color;

        // Coroutine
        StartCoroutine("PopFade");
    }

    private IEnumerator PopFade(){

        float elapsedTime = 0;

        Vector3 currentSize = ogSize;
        Color currentColor = ogColor;

        while(elapsedTime < duration){
            currentSize = Vector3.Lerp(ogSize, ogSize*growFactor, elapsedTime / duration);
            currentColor = Color.Lerp(ogColor, targetColor, elapsedTime / duration);

            elapsedTime += Time.unscaledDeltaTime;

            transform.localScale = currentSize;
            gameObject.GetComponent<Image>().color = currentColor;

            yield return null;
        }

        transform.localScale = ogSize;

        gameObject.GetComponent<Image>().color = ogColor;

    }
}
