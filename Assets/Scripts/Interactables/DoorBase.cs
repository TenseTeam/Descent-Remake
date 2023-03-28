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

    private void OnTriggerEnter(Collider other)
    {
        DoorOpening();
    }

    private void OnTriggerExit(Collider other)
    {
        DoorClosing();
    }

    protected void DoorOpening()
    {
        anim.SetTrigger("DoorOpens");
    }

    protected void DoorClosing()
    {
        anim.SetTrigger("DoorCloses");
    }
}
