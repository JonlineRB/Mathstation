using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amp : MonoBehaviour
{
    [SerializeField]
    private Color flashColor;
    private Color ogColor;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private float flashInterval;
    [SerializeField]
    private float attackInterval;
    
    void Start(){
        ogColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    
    public void InitAttack(){
        StartCoroutine("Flash");
        StartCoroutine("Attack");
    }

    private IEnumerator Flash(){
        while(true){
            gameObject.GetComponent<SpriteRenderer>().color=flashColor;
            yield return new WaitForSeconds(flashInterval);
            gameObject.GetComponent<SpriteRenderer>().color=ogColor;
            yield return new WaitForSeconds(flashInterval);
        }
    }

    void OnMouseDown(){
        StopAllCoroutines();
        gameObject.GetComponent<SpriteRenderer>().color=ogColor;
    }

    private IEnumerator Attack(){
        yield return new WaitForSeconds(attackInterval);
        StopCoroutine("Flash");
        gameObject.GetComponent<SpriteRenderer>().color=ogColor;
        GameObject.Instantiate(explosion,transform.position,Quaternion.identity);
        GameObject.Find("FightGame").GetComponent<FightMaster>().DecrementLife();
    }
}
