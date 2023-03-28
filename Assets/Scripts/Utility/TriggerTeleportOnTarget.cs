using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleportOnTarget : MonoBehaviour
{
    public Transform target;
    public string triggerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.velocity = Vector3.zero;
                other.transform.position = target.position;
            }
        }
    }
}
