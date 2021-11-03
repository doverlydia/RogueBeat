using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMissle : Missle
{
    public Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>().transform;
        targetPos = player.position;
    }
}
