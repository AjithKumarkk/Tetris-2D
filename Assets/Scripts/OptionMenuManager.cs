using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuManager : MonoBehaviour
{
    private bool isPause;

    [SerializeField] private AudioManager myAudioManager;

    private void Start()
    {
        myAudioManager = FindObjectOfType<AudioManager>();

        if (myAudioManager == null)
        {
            Debug.LogError("not found...");
        }

    }

    public void OnToggle()
    {
        isPause = !isPause;
        if (isPause)
        {
            myAudioManager.GetComponent<AudioSource>().Pause();
        }
        else
        {
            myAudioManager.GetComponent<AudioSource>().UnPause();
        }
    }

    public void BackGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
