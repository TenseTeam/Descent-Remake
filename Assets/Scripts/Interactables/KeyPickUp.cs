using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public bool RedKeyObtained = false;
    public GameObject UIRedKey;

    // Update is called once per frame
    void Update()
    {
        if (RedKeyObtained)
        {
            UIRedKey.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red Key"))
        {
            RedKeyObtained = true;
        }
    }
}
