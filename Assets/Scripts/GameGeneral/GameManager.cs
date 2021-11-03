using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : DungeonObject
{
    public Boss boss;
    public PlayerManager player;
    public GameObject levelCompletedScreen;
    public GameObject levelFailedScreen;

    private static GameManager instance = null;

    // Game Instance Singleton
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnBeat()
    {
        if (boss == null)
        {
            levelCompletedScreen.SetActive(true);
        }
        if (player == null)
        {
            levelFailedScreen.SetActive(true);
        }
    }
}
