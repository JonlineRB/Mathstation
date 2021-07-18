using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionFade : MonoBehaviour
{
    //Script makes invisible (alpha=0) sprites visible based on condition
    [SerializeField] private float fadeDuration;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color altColor;

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
    }

    public void InitFadeIn(){
        StartCoroutine("FadeIn");
    }

    private IEnumerator FadeIn(){
        float elapsed = 0f;

        while(elapsed <= fadeDuration){
            // Interpolate to be visible
            gameObject.GetComponent<SpriteRenderer>().color = Vector4.Lerp(defaultColor, altColor, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void InitFadeOut(){
        StartCoroutine("FadeOut");
    }

    private IEnumerator FadeOut(){
        float elapsed = 0f;

        while(elapsed <= fadeDuration){
            // Interpolate to be invisible
            gameObject.GetComponent<SpriteRenderer>().color = Vector4.Lerp(altColor, defaultColor, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
