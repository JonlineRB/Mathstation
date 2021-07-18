using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script manages cursour changes when hovering over the object
public class MouseOverCursorChange : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private bool locked = false;

    void OnMouseOver(){
        if(locked)
            ApplyDefaultCursor();
        else
            Cursor.SetCursor(cursorTexture, new Vector2(0.5f, 0.5f) * cursorTexture.height, CursorMode.ForceSoftware);
    }

    void OnMouseExit(){
        ApplyDefaultCursor();
    }

    void OnDestroy(){
        ApplyDefaultCursor();
    }

    void OnDisable(){
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
