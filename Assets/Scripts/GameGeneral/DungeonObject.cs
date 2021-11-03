using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonObject : MonoBehaviour
{
    void Awake()
    {
        Events.OnBeat.UpsertListener(OnBeat);
        Events.BossFight.UpsertListener(OnBossFight);
    }
    public virtual void OnBeat()
    {

    }

    public virtual void OnBossFight()
    {

    }

    private void OnDestroy()
    {
        Events.BossFight.RemoveListener(OnBossFight);
        Events.OnBeat.RemoveListener(OnBeat);
        if (TryGetComponent(out EnemyLanes enemy))
        {
            LaneManager.Instance.Lanes[0, (int) enemy.GetComponent<EnemyLanes>().enemyLane] = false;
        }
    }
}
