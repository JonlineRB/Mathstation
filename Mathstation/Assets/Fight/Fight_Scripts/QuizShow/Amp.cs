using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for QuizzShow's boss objects
public class Amp : MonoBehaviour
{
    [SerializeField]
    private Color flashColor;
    private Color ogColor; // Stores original color value
    [SerializeField]
    private GameObject explosion; // Reference to an explosion sprite prefab
    [SerializeField]
    private float flashInterval;
    [SerializeField]
    private float attackInterval;
    private bool isAttacking = false;
    
    void Start(){
        ogColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    
    // Method initiates attack, calls flash and attack coroutines
    public void InitAttack(){
        isAttacking = true;
        gameObject.GetComponent<MouseOverCursorChange>().Unlock();
        StartCoroutine("Flash");
        StartCoroutine("Attack");
    }

    // Flashes the object the color stored in flashColor
    private IEnumerator Flash(){
        while(true){
            gameObject.GetComponent<SpriteRenderer>().color=flashColor;
            yield return new WaitForSeconds(flashInterval);
            gameObject.GetComponent<SpriteRenderer>().color=ogColor;
            yield return new WaitForSeconds(flashInterval);
        }
    }

    // Clicking this object disables attacks
    void OnMouseDown(){
        StopAllCoroutines();
        isAttacking = false;
        gameObject.GetComponent<SpriteRenderer>().color=ogColor;
        gameObject.GetComponent<MouseOverCursorChange>().Lock();
    }

    // Attack couroutine
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
