using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : DoorBase
{
    private KeyPickUp playerKey;

    // Start is called before the first frame update
    void Start()
    {
        playerKey = new KeyPickUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerKey.RedKeyObtained)
        {
            DoorOpening();
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerKey.RedKeyObtained)
        {
            DoorClosing();
        }  
    }


}
