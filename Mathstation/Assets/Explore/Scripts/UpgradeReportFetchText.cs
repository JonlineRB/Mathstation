using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeReportFetchText : MonoBehaviour
{
    [SerializeField] private GameObject log;
    void OnEnable(){
        log = GameObject.Find("Player");
        gameObject.GetComponent<Text>().text = log.GetComponent<UpgradeLog>().ExportReport();
    }
}
