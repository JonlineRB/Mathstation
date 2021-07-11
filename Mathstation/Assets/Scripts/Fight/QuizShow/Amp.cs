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
    private bool isAttacking = false;
    
    void Start(){
        ogColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    
    public void InitAttack(){
        isAttacking = true;
        gameObject.GetComponent<MouseOverCursorChange>().Unlock();
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
        isAttacking = false;
        gameObject.GetComponent<SpriteRenderer>().color=ogColor;
        gameObject.GetComponent<MouseOverCursorChange>().Lock();
    }

    private IEnumerator Attack(){
        yield return new WaitForSeconds(attackInterval);
        StopCoroutine("Flash");
        gameObject.GetComponent<SpriteRenderer>().color=ogColor;
        GameObject.Instantiate(explosion,transform.position,Quaternion.identity);
        GameObject.Find("FightGame").GetComponent<FightMaster>().DecrementLife();
        isAttacking = false;
    }

    public bool IsAttackig(){
        return isAttacking;
    }
}
