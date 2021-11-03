using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Spawn : DungeonObject
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private bool spawned;
    [CanBeNull] private PlayerManager player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }
    public override void OnBeat()
    {
        if (player != null && !spawned && Vector2.Distance(player.gameObject.transform.position, this.transform.position) <= 10)
        {
            var EnemyToSpawn = enemies[Random.Range(0, enemies.Length)];

            if (LaneManager.Instance.Lanes[0, (int)EnemyToSpawn.GetComponent<EnemyLanes>().enemyLane] == false)
            {
                spawned = true;
                LaneManager.Instance.Lanes[0, (int)EnemyToSpawn.GetComponent<EnemyLanes>().enemyLane] = true;
                Instantiate(EnemyToSpawn, transform.position, Quaternion.identity, transform.parent);
            }
        }
    }

    public override void OnBossFight()
    {
        Destroy(this.gameObject);
    }
}
