using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCursorChange : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    void OnMouseEnter(){
        Cursor.SetCursor(cursorTexture, new Vector2(0.5f, 0.5f) * cursorTexture.height, CursorMode.ForceSoftware);
    }

    void OnMouseExit(){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    
}
