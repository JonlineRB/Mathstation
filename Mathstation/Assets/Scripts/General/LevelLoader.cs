using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

// Script loads levels.
// Used with buttons.
public class LevelLoader : MonoBehaviour
{
    // Load level by build index
    public static void LoadLevel(int index){
        EditorSceneManager.LoadScene(index);
    }

    // Load level by name.
    // Example: "Scenes/Menu".
    public static void LoadLevel(string name){
        EditorSceneManager.LoadScene(name);
    }
}
