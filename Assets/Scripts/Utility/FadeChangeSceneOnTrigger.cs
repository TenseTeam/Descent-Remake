using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple script for changing scene On Trigger Enter
/// </summary>
[RequireComponent(typeof(Collider))]
public class FadeChangeScene : MonoBehaviour
{
    public string triggerTag = "";
    public string sceneToLoad;
    public CameraFade cameraFadeComponent;
    public float timeToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            cameraFadeComponent.DoFadeIn(timeToLoad);
            StartCoroutine(LoadScene());
        }
    }


    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
