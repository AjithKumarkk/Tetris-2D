using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuManager : MonoBehaviour
{
   public static OptionMenuManager instance;

    public GameObject optionMenuObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if (scene.name != gameObject.scene.name)
        {
            ActivateOptionMenu();
        }
    }

    private void ActivateOptionMenu()
    {
        if (optionMenuObject != null)
        {
            optionMenuObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Its Error...");
        }
    }

    public void ShowOptionMenu()
    {
        ActivateOptionMenu();
    }

}
