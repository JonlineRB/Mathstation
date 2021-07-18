using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main gameloop script for the fight game
public class FightMaster : MonoBehaviour
{
    // Player's life points / hit points
    [SerializeField] private int life = 3;
    [SerializeField] private GameObject opponent; // Opponent game object reference
    public float energy = 0; // Current energy value
    [SerializeField] private int MaxEnergy;
    [SerializeField] private float nrg_charge_rate; // Charge rate
    // UI Object references
    [SerializeField] private GameObject sidePanel;
    [SerializeField] private GameObject heartManager;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject winWindow;
    // Lock for player energy charge
    [SerializeField] private bool pauseCharging = true;
    
    // Start is called before the first frame update
    void Start()
    {
        heartManager.GetComponent<HeartManager>().SetMaxHearts(life);
        heartManager.GetComponent<HeartManager>().SetHearts(life);
        // Calls dialogues. Handles case of no dialogue references
        gameObject.GetComponent<Dialogue_caller>().CallDialogue();
    }

    void Update()
    {

        // Cheat: Decrease player life with
        // if(Input.GetKeyDown(KeyCode.D)){
        //     DecrementLife();
        // }
        // If energy is at max, set a sprite
        if(energy==MaxEnergy){
            sidePanel.GetComponent<SidePanel>().toCharged();
        }
        // If not, default sprite
        else
            sidePanel.GetComponent<SidePanel>().toIdle();
    }

    void FixedUpdate(){
        // Charges player energy
        if(pauseCharging)
            return;
        if(energy < MaxEnergy)
            energy += nrg_charge_rate * Time.deltaTime;
        energy = Mathf.Clamp(energy, 0, (float)MaxEnergy);
    }

    // Events
    public void DecrementLife(){
        if(--life<=0){
            heartManager.GetComponent<HeartManager>().SetHearts(0);
            loseWindow.SetActive(true);
            if(opponent){
                GameObject.Destroy(opponent);
            }
            return;
        }
        heartManager.GetComponent<HeartManager>().SetHearts(life);
    }

    public bool consumeEnergyCharge(){
        if(energy==100){
            energy = 0;
            sidePanel.GetComponent<SidePanel>().toIdle();
            return true;
        }
            return false;
    }

    public void winGame(){
        winWindow.SetActive(true);
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

    public void ActivateOpponent(){
        opponent.GetComponent<Lock>().setLock(false);
    }

    public void setOpponent(GameObject newOpponent){
        opponent = newOpponent;
    }
    
}
