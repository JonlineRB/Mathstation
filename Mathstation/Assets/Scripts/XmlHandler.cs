using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

// XML interfacing script
public class XmlHandler : MonoBehaviour
{

    XmlDocument Xdoc = null;
    
    void Awake()
    {
        Xdoc = new XmlDocument(); //Instantiate
        
        Xdoc.Load(Path.Combine(Application.streamingAssetsPath, "TextQuestions.xml")); //load XML file from streaming assets

        XmlElement root = Xdoc.DocumentElement;
    }

    public string FetchQuestion(string type){

        XmlElement root = Xdoc.DocumentElement;

        XmlNode dataNode = root.SelectSingleNode(type); //Gets the node of the correct type

        int randomIndex = Random.Range(0, dataNode.ChildNodes.Count);

        string result = dataNode.ChildNodes[randomIndex].InnerText;

        return result;
    }

    
}
