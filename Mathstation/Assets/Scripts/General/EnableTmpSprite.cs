using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTmpSprite : MonoBehaviour
{
    [SerializeField]
    private GameObject externalSprite;
    [SerializeField]
    private float duration;

    public void InitExternalSprite(){
        StartCoroutine("ShowExternalSprite");
    }

    private IEnumerator ShowExternalSprite(){
        externalSprite.SetActive(true);
        yield return new WaitForSeconds(duration);
        externalSprite.SetActive(false);
    }
    
}
