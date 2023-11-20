using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudio;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    public void BackGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }

    public void ShowOptions()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void ShowHowToPlay()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

}
