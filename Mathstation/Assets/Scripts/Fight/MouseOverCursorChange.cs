using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCursorChange : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private bool locked = false;

    void OnMouseEnter(){
        if(locked)
            return;
        Cursor.SetCursor(cursorTexture, new Vector2(0.5f, 0.5f) * cursorTexture.height, CursorMode.ForceSoftware);
    }

    void OnMouseExit(){
        ApplyDefaultCursor();
    }

    void OnDestroy(){
        ApplyDefaultCursor();
    }

    public void ApplyDefaultCursor(){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Lock(){
        locked = true;
    }

    public void Unlock(){
        locked = false;
    }
    
}
