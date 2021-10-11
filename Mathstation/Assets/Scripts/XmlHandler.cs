using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.Networking;

// XML interfacing script
public class XmlHandler : MonoBehaviour
{

    private bool loaded = false;

    XmlDocument Xdoc = new XmlDocument(); //Instantiate

    string Nothing(){
        return "nothing";
    }

    IEnumerator LoadFileText(string fileName){        
        string filepath = Path.Combine(Application.streamingAssetsPath, fileName);

        string result;

        // Check if the current version is WebGL
        if(filepath.Contains("://") || filepath.Contains(":///")){
             WWW www = new WWW(filepath);
             yield return www;
             result = www.text;
        }
        else
            result = File.ReadAllText(filepath);
        
        Xdoc.LoadXml(result);

        XmlElement root = Xdoc.DocumentElement;

    }
    
    void Awake()
    {

        StartCoroutine(LoadFileText("TextQuestions.xml"));

    }

    public string FetchQuestion(string type){

        XmlElement root = Xdoc.DocumentElement;

        XmlNode dataNode = root.SelectSingleNode(type); //Gets the node of the correct type

        int randomIndex = Random.Range(0, dataNode.ChildNodes.Count);

        string result = dataNode.ChildNodes[randomIndex].InnerText;

        return result;
    }

    
}
