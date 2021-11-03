using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyLanes
{
    [SerializeField] Animator anim;
    [SerializeField] private PlayerManager player;

    public override void OnBeat()
    {
        if (player.isOnBossFight)
        {
            anim.Play("Attack");
            Movement();
            Attack();
        }
    }
}
