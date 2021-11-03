using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    private Boss boss;

    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
        boss.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Events.BossFight.Invoke();
            boss?.gameObject.SetActive(true);
        }
    }
}
