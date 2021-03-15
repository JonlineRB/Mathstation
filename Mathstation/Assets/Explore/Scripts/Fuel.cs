using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float fuel;

    void Start(){
        consumptionRate = consumptionRates[consumptionIndex];
        capacity = capacities[capacitiesIndex];
        fuel = (float)capacity;
        capacityText.GetComponent<Text>().text = capacity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isConsuming){
            fuel -= consumptionRate * Time.deltaTime;
        }
        fuelText.GetComponent<Text>().text = ((int)fuel).ToString();

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

    public void CapacityUp(){
        if(capacities.Count > capacitiesIndex + 1)
            capacity = capacities[++capacitiesIndex];
        ResetFuel();
        capacityText.GetComponent<Text>().text = capacity.ToString();
    }

    public void RateUp(){
        if(consumptionRates.Count > consumptionIndex + 1)
            consumptionRate = consumptionRates[++consumptionIndex];
        ResetFuel();
    }
}
