using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [field: SerializeField, Header("Timer"), TextArea(3, 10)]
    public string Text { get; private set; }
    [field: SerializeField]
    public int Time { get; set; }
    [field: SerializeField]
    public TMP_Text TimerText { get; private set; }

    public void StartTimer()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        while(Time > 0)
        {
            Time--;
            TimerText.text = Text + Time.ToString();
            yield return new WaitForSeconds(1);
        }

        SendMessage("SetAction", SendMessageOptions.DontRequireReceiver);
    }
}
