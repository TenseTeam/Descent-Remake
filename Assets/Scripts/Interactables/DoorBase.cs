using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBase : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        DoorOpening();
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        DoorClosing();
    }

    protected void DoorOpening()
    {
        anim.SetTrigger("Open");
    }

    protected void DoorClosing()
    {
        anim.SetTrigger("Close");
    }
}
