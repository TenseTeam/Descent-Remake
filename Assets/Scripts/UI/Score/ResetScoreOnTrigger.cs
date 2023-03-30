using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreOnTrigger : MonoBehaviour
{
    public string triggerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            ScoreSingleton.instance.ResetScore();
        }
    }
}
