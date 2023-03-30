using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extension.SerializableClasses.Audio;
using Extension.Audio;

/// <summary>
/// Simple script that plays an audio on trigger enter
/// </summary>
public class AudioOnTrigger : MonoBehaviour
{
    public List<string> bumpableTags = new List<string>() {  };
    public AudioSFX audioEffect;

    private void OnTriggerEnter(Collider hit)
    {
        if (bumpableTags.Contains(hit.transform.tag))
        {
            AudioExtension.PlayClipAtPoint(audioEffect, hit.ClosestPoint(transform.position));
        }
    }
}
