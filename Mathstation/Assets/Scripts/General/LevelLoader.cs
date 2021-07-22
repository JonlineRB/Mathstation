using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script loads levels.
// Used with buttons.
public class LevelLoader : MonoBehaviour
{
    // Load level by build index
    public static void LoadLevel(int index){
        SceneManager.LoadScene(index);
    }

    // Load level by name.
    // Example: "Scenes/Menu".
    public static void LoadLevel(string name){
        SceneManager.LoadScene(name);
    }
}
