using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBase : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    [Tooltip("Distance from the player where the door opens")]
    public float DistanceRange;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        DoorOpening();
    }

    protected void DoorOpening()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < DistanceRange)
        {
            anim.SetBool("Door Opens", true);
        }
    }
}
