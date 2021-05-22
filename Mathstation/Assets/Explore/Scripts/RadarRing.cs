using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRing : MonoBehaviour, MathCaller
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowDistance;
    [SerializeField] private List<GameObject> fadies;
    [SerializeField] private GameObject background;
    // [SerializeField] private bool active = false;
    [SerializeField] private GameObject[] pointingAt;
    [SerializeField] private GameObject mathEditor;
    [SerializeField] private GameObject dial;
    private bool solved = false; //Turns true once math problem solved

    void OnTriggerEnter2D(Collider2D other){
        //put player in the center of the object
        other.GetComponent<ArtifactInterpolation>().InitInterpolation(transform.position);

        if(!solved){
            CallMathEditor();
        }
        else{
            Scan();
        }
        
    }

    private void Scan(){
        fadies = new List<GameObject>();
        fadies.Add(background);
        foreach(GameObject pointee in pointingAt){
            if(!pointee.activeSelf)
                continue;
            //instantiate an arrow
            //add it to the list of fade objects
            Vector3 direction = (pointee.transform.position - transform.position).normalized;
            GameObject arrowInstance = GameObject.Instantiate(arrow, transform.position + direction * arrowDistance,
            Quaternion.Euler(0,0,Vector3.SignedAngle(Vector3.up, direction, Vector3.forward)), transform);
            fadies.Add(arrowInstance);
        }
        foreach(GameObject fadie in fadies){
            fadie.GetComponent<ConditionFade>().InitFadeIn();
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        foreach(GameObject fadie in fadies){
            fadie.GetComponent<ConditionFade>().InitFadeOut();
        }
    }

    public void CallMathEditor()
    {
        GameObject editor = GameObject.Instantiate(mathEditor);
        editor.GetComponent<EditorMaster>().SetReport(gameObject);
    }

    public void MathSuccess()
    {
        solved = true;
        dial.GetComponent<Rotate>().enabled = true;
        //garphic transformation here
        Scan(); 
    }
}
