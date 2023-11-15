using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject pauseMenuUI;

    public static bool isPaused = false;

    public TextMeshProUGUI gameOverText;
    public GameObject gameOverUI;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
        SpawnBlock();
       
    }

    // Update is called once per frame
    public void SpawnBlock()
    {
        int randomBlock = Random.Range(0, blocks.Length);
        Instantiate(blocks[randomBlock], transform.position, blocks[randomBlock].transform.rotation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    
}
