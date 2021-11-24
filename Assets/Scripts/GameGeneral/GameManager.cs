using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject levelCompletedScreen;
    public TMP_Text scoreText;
    public GameObject levelFailedScreen;
    public GameObject levelEssentials;
    public Inventory inventory;
    public GameObject shootButton;

    [HideInInspector] public Boss? boss;
    [HideInInspector] public PlayerManager? player;

    [HideInInspector] public int difficulty = 1;
    [HideInInspector] public int overallSuccesfullShots = 0;
    [HideInInspector] public int enemiesKilled = 0;
    [HideInInspector] public int score = 0;
    [HideInInspector] public int highScore = 0;

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
                score = CalculateScore();
                highScore = PlayerPrefs.GetInt("highScore");

                if (score > highScore)
                    highScore = score;

                PlayerPrefs.SetInt("highScore", highScore);
                PlayerPrefs.Save();

                scoreText.text = "Level Completed! Your score: " + score + " High Score: " + highScore;

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
            {
                levelEssentials.SetActive(false);
            }

            if (inventory.InventoryScreen != null)
            {
                inventory.InventoryScreen.SetActive(false);
            }
            else
            {
                if (FindObjectOfType<_displayInventory>())
                    inventory.InventoryScreen = FindObjectOfType<_displayInventory>().gameObject;
            }
        }
    }

    public void Shoot()
    {
        if (player != null)
        {
            bool succesfulShot = player.weapon.Shoot();
            if (succesfulShot)
            {
                overallSuccesfullShots++;
            }
        }
    }

    public int CalculateScore()
    {
        return (int)((overallSuccesfullShots * enemiesKilled) - (10 * (player.gameObject.GetComponent<Damagable>().MaxValue - player.gameObject.GetComponent<Damagable>().CurrentValue)));
    }
}
