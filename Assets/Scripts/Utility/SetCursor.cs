using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public bool isVisibile = false;
    public CursorLockMode cursorLockMode;


    void Awake()
    {
        Cursor.visible = isVisibile;
        Cursor.lockState = cursorLockMode;
    }
}
