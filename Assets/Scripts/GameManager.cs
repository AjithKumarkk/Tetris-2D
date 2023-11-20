using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private int maxScores = 10;

    public ScoreDisplay scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
        UpdateScore();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = " Score :" + score;
    }

    public int GetScore() 
    { 
        return score; 
    }

    // Call this method when the game is over to update and save high scores
    public void GameOver()
    {
        // Update and save high scores
        UpdateHighScores();

        // Display the updated high scores in the ScoreDisplay
        scoreDisplay.LoadAndDisplayHighScores();
    }

    // Update and save high scores
    void UpdateHighScores()
    {
        // Retrieve the current top 10 scores from PlayerPrefs
        List<int> highScores = new List<int>();

        for (int i = 1; i <= maxScores; i++)
        {
            int currentScore = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(currentScore);
        }

        // Add the current score to the list
        highScores.Add(score);

        // Sort the scores in descending order
        highScores.Sort((a, b) => b.CompareTo(a));

        // Take only the top 10 scores
        highScores = highScores.GetRange(0, Mathf.Min(maxScores, highScores.Count));

        // Save the updated high scores to PlayerPrefs
        for (int i = 1; i <= maxScores; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, i <= highScores.Count ? highScores[i - 1] : 0);
        }

        // Save the changes
        PlayerPrefs.Save();
    }


}
