using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static void LoadLevel(int index){
        EditorSceneManager.LoadScene(index);
    }

    public static void LoadLevel(string name){
        EditorSceneManager.LoadScene(name);
    }
}
