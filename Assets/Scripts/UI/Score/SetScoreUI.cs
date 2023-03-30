using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScoreUI : MonoBehaviour
{
    [field: SerializeField, Header("Text UI")]
    public TMP_Text Text { get; set; }

    private void Start()
    {
        ScoreSingleton.instance.ScoreText = Text;
    }
}
