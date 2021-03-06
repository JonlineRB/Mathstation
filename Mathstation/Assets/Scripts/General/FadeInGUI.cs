using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInGUI : MonoBehaviour
{
    [SerializeField]
    private float initSizeFactor;
    [SerializeField]
    private float duration;
    private Vector3 ogScale;
    

    public void OnEnable(){
        //preamble
        // GameObject.Find("MineGame").GetComponent<ClickLock>().Lock();

        //resize to make it bigger, make the color transparent, init a coroutine to make it like before
        ogScale = transform.localScale;
        transform.localScale *= initSizeFactor;
        gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
        StartCoroutine("FadeIn");
    }

    private IEnumerator FadeIn(){
        //use interpolation here
        float elapsedTime = 0;
        Vector3 currentSize = transform.localScale;
        Vector3 initSize = currentSize;

        Color currentColor = gameObject.GetComponent<Image>().color;
        Color initColor = currentColor;

        while(elapsedTime < duration){
            currentSize = Vector3.Lerp(initSize, ogScale, elapsedTime/duration);

            currentColor = Color.Lerp(initColor, Color.white, elapsedTime / duration);

            elapsedTime += Time.unscaledDeltaTime;


            transform.localScale = currentSize;
            gameObject.GetComponent<Image>().color = currentColor;
            yield return null;
        }
        transform.localScale = ogScale;
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
