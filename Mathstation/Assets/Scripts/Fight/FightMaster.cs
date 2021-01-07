using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject mathEditor;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private GameObject opponent;
    public float energy = 0;
    [SerializeField]
    private int MaxEnergy;
    [SerializeField]
    private float nrg_charge_rate;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<HeartManager>().setHearts(2);
    }

    // Update is called once per frame
    void Update()
    {

        //temporary key bound events
        if(Input.GetKeyDown(KeyCode.D)){
            DecrementLife();
        }
    }

    void FixedUpdate(){
        if(energy < MaxEnergy)
            energy += nrg_charge_rate * Time.deltaTime;
        energy = Mathf.Clamp(energy, 0, (float)MaxEnergy);
    }

    //events
    public void DecrementLife(){
        if(--life<=0)
            Debug.Log("Game Over!");
        Debug.Log("Life is: " + life);
    }

    public void callEditor(){
        GameObject.Instantiate(mathEditor);
    }

    public void mathSuccess(){
    }

    public void mathFail(){

    }

    public void winGame(){

    }

    public void mainMenu(){}

    
}
