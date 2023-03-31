using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public bool isVisibile = false;
    public CursorLockMode cursorLockMode;
    public Texture2D cursorTexture;


    void Awake()
    {
        Cursor.visible = isVisibile;
        Cursor.lockState = cursorLockMode;

        if(cursorTexture)
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
