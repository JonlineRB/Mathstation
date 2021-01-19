using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockstormPhase2Rock : MonoBehaviour
{
    [SerializeField]
    private float growth;
    private float initSize;
    [SerializeField]
    private float timer;
    private float elapsedTime = 0;
    private float lerpScaleValue;
    [SerializeField]
    private Color targetColor;
    private Color initialColor;
    private Color lerpColorValue;
    [SerializeField]
    private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        initSize = transform.localScale.x;
        initialColor = gameObject.GetComponent<SpriteRenderer>().color;
        //begin coroutine that consumes the rock and damages the player
        StartCoroutine(Consume());
        
    }

    // Update is called once per frame
    void Update()
    {
        //lerp size
        lerpScaleValue = Mathf.Lerp(initSize, growth, elapsedTime / timer);
        transform.localScale = new Vector3(lerpScaleValue, lerpScaleValue, lerpScaleValue);

        //lerp color
        lerpColorValue = Color.Lerp(initialColor, targetColor, elapsedTime / timer);
        gameObject.GetComponent<SpriteRenderer>().color = lerpColorValue;

        elapsedTime += Time.deltaTime;
    }

    IEnumerator Consume(){
        yield return new WaitForSeconds(timer);
        GameObject.FindObjectOfType<FightMaster>().DecrementLife();
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
    }

    void OnMouseDown(){
        gameObject.GetComponent<ExplodeRocks>().Explode(transform.position);
        GameObject.Destroy(gameObject);
    }
}
