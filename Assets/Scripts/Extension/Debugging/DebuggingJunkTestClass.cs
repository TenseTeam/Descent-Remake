#if DEBUG && UNITY_EDITOR

using Extension.Finders;
using UnityEngine;

public class DebuggingJunkTestClass
{
    [RuntimeInitializeOnLoadMethod]
    public void Log()
    {
        Debug.Log("AD");
    }
}

#endif