using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Extension.Finders;


/// <summary>
/// ScoreSingleton class implementing the singleton design pattern
/// to maintain a single instance of the score throughout multiple scenes
/// </summary>
public class ScoreSingleton : MonoBehaviour
{
    public static ScoreSingleton instance; //static instance of ScoreSingleton

    public float Multiplier { get; set; } = 1;

    public TMP_Text ScoreText { get; set; } // Reference to the text component for displaying the score
    private float _score = 0f; // Reference to the scriptable object for storing score

    private void Awake()
    {
        // Check if an instance of ScoreSingleton already exists
        if (instance == null)
        {
            // If not, set this object as the instance and subscribe to the SceneLoaded event
            instance = this;
            // Prevent this object from being destroyed when changing scenes
            DontDestroyOnLoad(this);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Add to the score
    /// </summary>
    /// <param name="toAdd">The amount to add to the score</param>
    public void AddScore(int toAdd)
    {
        // Add to the score stored in the scriptable object and multiply it by the multiplier
        _score += (int)((float)toAdd * Multiplier);
        // Update the text with the new score
        UpdateText();
    }

    public void RemoveScore(int toRemove)
    {
        int totalToRemove = (int)((float)toRemove * Multiplier);

        if (_score - totalToRemove < 0)
        {
            _score = 0;
        }
        else
        {
            _score -= totalToRemove;
        }

        // Update the text with the new score
        UpdateText();
    }
    public void ResetScore()
    {
        _score = 0f;
    }


    /// <summary>
    /// Update the text component with the current score
    /// </summary>
    private void UpdateText()
    {
        ScoreText.text = _score.ToString();
    }
}
