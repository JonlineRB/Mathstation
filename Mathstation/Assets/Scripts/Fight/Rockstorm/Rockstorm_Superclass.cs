using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rockstorm_Superclass : MonoBehaviour
{

    protected GameObject fightGame;
    // Start is called before the first frame update
    protected void Start()
    {
        fightGame = GameObject.Find("FightGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Damage();
    }

    public abstract void Damage();

    public abstract void Destroy();

    public void RecieveMathDamage(){
        Destroy();
    }

    protected bool CheckConsumeEnergy(){
        if(fightGame.GetComponent<FightMaster>().consumeEnergyCharge()){
            fightGame.GetComponent<FightMaster>().setPauseCharging();
            gameObject.GetComponent<MathCaller>().CallMathEditor();
            GetComponent<CircleCollider2D>().enabled = false;
            return true;
        }
        return false;
    }
}
