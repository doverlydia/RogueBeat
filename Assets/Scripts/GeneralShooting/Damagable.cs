using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : Progressable
{
    private void Start()
    {
        MaxValue *= GameManager.Instance.difficulty;
        CurrentValue *= GameManager.Instance.difficulty;
    }
    private void Update()
    {
        if (CurrentValue <= 0)
        {
            if(this.gameObject.layer == 6)
            {
                GameManager.Instance.enemiesKilled++;
            }
            Destroy(this.gameObject);
        }
    }
}
