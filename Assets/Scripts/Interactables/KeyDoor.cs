using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : DoorBase
{
    private KeyPickUp playerKey;

    // Start is called before the first frame update


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out KeyPickUp pick))
        {
            if (pick.RedKeyObtained)
            {
                DoorOpening();
            }  
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out KeyPickUp pick))
        {
            if (pick.RedKeyObtained)
            {
                DoorClosing();
            }
        }
    }


}
