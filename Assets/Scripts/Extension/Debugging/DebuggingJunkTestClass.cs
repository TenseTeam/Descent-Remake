#if DEBUG && UNITY_EDITOR

using Extension.Finders;
using UnityEngine;

public class DebuggingJunkTestClass : MonoBehaviour
{
    float a = 50;
    GameObject go;

    private void Start()
    {
        go = new GameObject("a");
        go.DestroyLastComponentOfType<Collider>();
    }
}

#endif