using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script handles player fuel in the explore game
public class Fuel : MonoBehaviour
{
    private bool isConsuming = false;
    private float consumptionRate;
    private int capacity;

    private int consumptionIndex;
    private int capacitiesIndex;

    [SerializeField] private List<float> consumptionRates;
    [SerializeField] private List<int> capacities;
    [SerializeField] private GameObject fuelText;
    [SerializeField] private GameObject capacityText;
    [SerializeField] private GameObject rateText;
    private float fuel;

    void Start(){
        consumptionRate = consumptionRates[consumptionIndex];
        capacity = capacities[capacitiesIndex];
        fuel = (float)capacity;

        //deprecated, left in for potential future use
        // capacityText.GetComponent<Text>().text = capacity.ToString();
        // rateText.GetComponent<Text>().text = consumptionRate.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Reduce fuel value while consuming it
        if(isConsuming){
            fuel -= consumptionRate * Time.deltaTime;
        }
        fuelText.GetComponent<Text>().text = ((int)fuel).ToString();

        // Initiate a player reset if fuel depletes
        if(fuel<=0){
            gameObject.GetComponent<Reset>().InitReset();
        }
    }

    public void SetConsuming(bool value){
        isConsuming = value;
    }

    public void ResetFuel(){
        fuel = capacity;
    }

    //Invoked when the capacity ring is consumed
    public void CapacityUp(){
        if(capacities.Count > capacitiesIndex + 1)
            capacity = capacities[++capacitiesIndex];
        ResetFuel();
        capacityText.GetComponent<Text>().text = capacity.ToString();
        gameObject.GetComponent<UpgradeLog>().CapacityUp();
    }

    //Invoked when the fuel conspumtion ring is consumed
    public void RateUp(){
        if(consumptionRates.Count > consumptionIndex + 1)
            consumptionRate = consumptionRates[++consumptionIndex];
        ResetFuel();
        gameObject.GetComponent<UpgradeLog>().ConsumptionUp();
        rateText.GetComponent<Text>().text = consumptionRate.ToString();
    }

    public float GetFuel(){
        return fuel;
    }
}
