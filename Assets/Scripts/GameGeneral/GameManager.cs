using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Boss? boss;
    public PlayerManager? player;
    public GameObject levelCompletedScreen;
    public GameObject levelFailedScreen;
    public GameObject levelEssentials;

    public int difficulty = 1;

    public static GameManager instance;

    // Game Instance Singleton
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (boss == null)
            {
                levelCompletedScreen.SetActive(true);
            }
            else
            {
                levelCompletedScreen.SetActive(false);
            }
            if (player == null)
            {
                levelFailedScreen.SetActive(true);
            }
            else
            {
                levelFailedScreen.SetActive(false);
            }
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && levelEssentials != null)
        {
            levelEssentials.SetActive(true);
            boss = FindObjectOfType<Boss>();
            player = FindObjectOfType<PlayerManager>();
        }
        else
        {
            if (levelEssentials != null)
                levelEssentials.SetActive(false);
        }
    }
}
