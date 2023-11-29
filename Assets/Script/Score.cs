using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int beatsDestroyed = 0;  // New variable to track the number of beats destroyed
    private Text scoreText;

    void Start()
    {
        // Get the Text component from the attached GameObject
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    // Method to update the score text
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString() + "\n Hit: " + beatsDestroyed.ToString();
    }

    // Method to increment the score by a given value
    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    // Method to increment the beatsDestroyed by a given value
    public void IncrementBeatsDestroyed(int value)
    {
        beatsDestroyed += value;
        UpdateScoreText();
    }
}
