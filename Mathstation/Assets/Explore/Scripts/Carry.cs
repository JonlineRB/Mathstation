using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handles objects that are carried by the player
public class Carry : MonoBehaviour
{

    public enum Carriables {None, Moon, Cork, IceCube} //The types of objects
    private GameObject carryReference; //Reference to an instance of a carriable object
    //Prefab references
    [SerializeField] private GameObject carriedMoon;
    [SerializeField] private GameObject carriedCork;
    [SerializeField] private GameObject carriedIceCube;
    //Reference to the type of the object currently being carried
    private Carriables carrying;
    // Start is called before the first frame update
    void Start()
    {
        carrying = Carriables.None; // Player is not carrying anything initially
    }

    //Set the object that the player carries.
    // @ Carriables value
    // The value of type Carriable that the player carries.
    // All the other references are handled in this method accordingly.
    public void SetCarrying(Carriables value){
        carrying = value;
        switch (carrying){
            case Carriables.None:
                GameObject.Destroy(carryReference);    
                break;
            case Carriables.Moon:
                GameObject moon = GameObject.Instantiate(carriedMoon, transform.position, Quaternion.identity);
                moon.GetComponent<FollowPosition>().SetFollowing(gameObject);
                carryReference = moon;
                break;
            case Carriables.Cork:
                GameObject cork = GameObject.Instantiate(carriedCork, transform.position, Quaternion.identity);
                cork.GetComponent<FollowPosition>().SetFollowing(gameObject);
                carryReference = cork;
                break;
            case Carriables.IceCube:
                GameObject iceCube = GameObject.Instantiate(carriedIceCube, transform.position, Quaternion.identity);
                iceCube.GetComponent<FollowPosition>().SetFollowing(gameObject);
                carryReference = iceCube;
                break;
        }
        if(carrying == Carriables.None)
            GameObject.Destroy(carryReference);
    }

    public Carriables GetCarrying(){
        return carrying;
    }

    public bool IsCarrying(){
        return carrying!=Carriables.None;
    }
}
