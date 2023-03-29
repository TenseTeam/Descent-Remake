using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [field: SerializeField, Header("Timer")]
    public int Time { get; set; }

    [field: SerializeField]
    public TMP_Text TimerText { get; private set; }


    [ContextMenu("Try")]
    public void StartTimer()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        while(Time >= 0)
        {
            TimerText.text = Time.ToString();
            Time--;
            yield return new WaitForSeconds(1);
        }

        SendMessage("SetAction", SendMessageOptions.DontRequireReceiver);
    }
}
