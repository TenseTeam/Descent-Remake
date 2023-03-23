using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScenes : MonoBehaviour
{
    [ContextMenu("Reload Scene")]
    public virtual void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}

