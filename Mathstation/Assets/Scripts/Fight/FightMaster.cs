using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMaster : MonoBehaviour
{
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private GameObject opponent;
    public float energy = 0;
    [SerializeField]
    private int MaxEnergy;
    [SerializeField]
    private float nrg_charge_rate;
    [SerializeField]
    private GameObject sidePanel;
    private bool lightSidePanel = true;
    [SerializeField]
    private GameObject heartManager;
    private bool pauseCharging = false;
    // Start is called before the first frame update
    void Start()
    {
        heartManager.GetComponent<HeartManager>().SetMaxHearts(life);
        heartManager.GetComponent<HeartManager>().SetHearts(life);
        //begin dialogue
    }

    // Update is called once per frame
    void Update()
    {

        //temporary key bound events
        if(Input.GetKeyDown(KeyCode.D)){
            DecrementLife();
        }
        if(energy==100 && lightSidePanel){
            sidePanel.GetComponent<SidePanel>().toCharged();
            lightSidePanel = false;
        }
    }

    void FixedUpdate(){
        if(pauseCharging)
            return;
        if(energy < MaxEnergy)
            energy += nrg_charge_rate * Time.deltaTime;
        energy = Mathf.Clamp(energy, 0, (float)MaxEnergy);
    }

    //events
    public void DecrementLife(){
        if(--life<=0){
            heartManager.GetComponent<HeartManager>().SetHearts(0);
            Debug.Log("Game Over!");
            return;
        }
        heartManager.GetComponent<HeartManager>().SetHearts(life);
        Debug.Log("Life is: " + life);
    }

    public bool consumeEnergyCharge(){
        if(energy==100){
            energy = 0;
            sidePanel.GetComponent<SidePanel>().toIdle();
            lightSidePanel = true;
            return true;
        }
            return false;
    }

    public void winGame(){

    }

    public void mainMenu(){

    }

    public void setPauseCharging(){
        pauseCharging = true;
    }

    public void releasePauseCharging(){
        pauseCharging = false;
    }

    public void energyGain(float value){
        energy += value;
        energy = Mathf.Clamp(energy, 0, (float)MaxEnergy);
    }
    
}
