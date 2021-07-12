using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script sets the text at the end of level report.
// The text is based on the player's UpgradeLog script.
public class UpgradeReportFetchText : MonoBehaviour
{
    [SerializeField] private GameObject log;
    void OnEnable(){
        log = GameObject.Find("Player");
        gameObject.GetComponent<Text>().text = log.GetComponent<UpgradeLog>().ExportReport();
    }
}
