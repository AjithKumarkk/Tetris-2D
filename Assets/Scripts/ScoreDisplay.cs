using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Awake()
    {
        // Load and display high scores when the scene starts

        LoadAndDisplayHighScores();
    }

    public void LoadAndDisplayHighScores()
    {

        // Retrieve the top 10 scores from PlayerPrefs or any other data storage mechanism
        List<int> highScores = LoadHighScores();

        // Display the top 10 scores
        DisplayHighScores(highScores);
    }

    // Retrieve the top 10 scores from PlayerPrefs or any other data storage mechanism
    List<int> LoadHighScores()
    {
        List<int> highScores = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            // Assuming you store scores in PlayerPrefs with keys like "HighScore1", "HighScore2", etc.
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }

        return highScores;
    }

    // Display the top 10 scores in the UI
    void DisplayHighScores(List<int> highScores)
    {
        // Update the UI text with the high scores
        string highScoreString = "High Scores:\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreString += (i + 1) + ". " + highScores[i] + "\n";
        }

        highScoreText.text = highScoreString;
    }

    public void BackGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
