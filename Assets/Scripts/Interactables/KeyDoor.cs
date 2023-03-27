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

    // Update is called once per frame
    void Update()
    {
        if (playerKey.RedKeyObtained)
        {
            DoorOpening();
        }
    }


}
