using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Superclass for ring type objects (Consumable upgrades for the player)
public class Ring : MonoBehaviour, MathCaller
{
    [SerializeField] protected float interpolationDistance; //Distance traveled during interpolation
    [SerializeField] protected GameObject moveMarker; //The player's marker, which is disabled when consuming the ring
    [SerializeField] protected float duration; // duration of interpolation
    [SerializeField] protected float size; //Factor to which the ring is scaled upon consumption (make it smaller as it fades)
    [SerializeField] protected float windUp; //Intermission between the interpolation and math problem solving
    [SerializeField] protected GameObject lowerPart; //Reference to the ring's lower part (Seperate for the visual effects, player flys through the ring)
    [SerializeField] private GameObject mathEditor; //Reference to the math editor prefab
    protected GameObject player; //Reference to the player object

    //Trigger interpolation when player enters the collider
    public void OnTriggerEnter2D(Collider2D other){
        //Disable moveMarker
        if(!moveMarker)
            moveMarker = GameObject.Find("TargetMarker");
        moveMarker.SetActive(false);
        //Set fuel to stop consumption
        other.GetComponent<Fuel>().SetConsuming(false);
        //Set player reference to the GameObject that entered the collider
        player = other.gameObject;
        //Disable this collider
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //Interpolate player into a specified position
        other.GetComponent<PlayerRingInterpolation>().Init1stInterpolation(transform.position - new Vector3(0, interpolationDistance, 0), gameObject);
    }

    //Coroutine to handle the visuals of ring consumption by the player
    public IEnumerator Consume(){
        //apply the ring's effect to player here
        ApplyRingEffect();
        //windUp to delay the consumption effect
        yield return new WaitForSeconds(windUp);
        //time counter
        float elapsed= 0;
        //store current size of ring
        Vector3 currentSize = transform.localScale;
        //calculate final size using current scale times size factor
        Vector3 endSize = currentSize * size;

        //Store current color
        Color currentColor = transform.GetComponent<SpriteRenderer>().color;
        //end color is transparent
        Color endColor = new Color(255f,255f,255f,0);

        //Interpolation loop
        while(elapsed < duration){
            transform.localScale = Vector3.Lerp(currentSize, endSize, elapsed / duration);
            transform.GetComponent<SpriteRenderer>().color = Color.Lerp(currentColor, endColor, elapsed / duration);
            lowerPart.GetComponent<SpriteRenderer>().color = Color.Lerp(currentColor, endColor, elapsed / duration);

            elapsed += Time.deltaTime;

            yield return null;
        }

        //Disable the object once consumption interpolation ends
        gameObject.SetActive(false);
    }

    //To be overwritten by subclasses specific upgrade effects
    protected virtual void ApplyRingEffect(){}

    //Mathcaller
    public void CallMathEditor()
    {
        //Instantiates math editor interface
        GameObject editor = GameObject.Instantiate(mathEditor);
        //Set the object to which the editor reports
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    public void MathSuccess()
    {
        //Math success initiates the playr object's coroutine PlayerRingInterpolation._Interpolation_2
        StartCoroutine(player.GetComponent<PlayerRingInterpolation>().Interpolation_2());
    }

}
