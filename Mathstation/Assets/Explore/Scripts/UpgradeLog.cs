﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLog : MonoBehaviour
{
    private int speedCount, capacityCount, consumptionCount = 0;

    public void SpeedUp(){
        speedCount++;
    }

    public void CapacityUp(){
        capacityCount++;
    }

    public void ConsumptionUp(){
        consumptionCount++;
    }

    public string ExportReport(){
        string output = "";
        output += speedCount;
        output += "\n";
        output += capacityCount;
        output += "\n";
        output += consumptionCount;

        return output;
    }
}
