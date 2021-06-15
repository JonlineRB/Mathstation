using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XmlHandler : MonoBehaviour
{

    XmlDocument Xdoc = null;
    
    void Start()
    {
        Xdoc = new XmlDocument(); //Instantiate
        Debug.Log("The current directory is: " + Application.dataPath);
        Xdoc.Load(Application.dataPath + "/data.xml"); //Load XML file

        XmlElement root = Xdoc.DocumentElement; //Get follow node
        Debug.Log("The root element is: "+ root.Name);

        XmlNode dataNode = root.SelectSingleNode("data"); //Get the child nodes under root
        Debug.Log("Node name" + dataNode.Name);

        // for(int i=0; i<dataNode.ChildNodes.Count; i++)
        // {
        //     Debug.Log("Text content " + dataNode.ChildNodes[i].InnerText); //Get text content
        // }

        int randomIndex = Random.Range(0, dataNode.ChildNodes.Count);

        string result = dataNode.ChildNodes[randomIndex].InnerText;

        Debug.Log("Random fetch content " + result);
    }

    
}
