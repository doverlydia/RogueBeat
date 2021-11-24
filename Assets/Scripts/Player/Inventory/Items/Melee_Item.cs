using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Item : Item
{
    [SerializeField] GameObject meleeAttack;
    protected override void Ability()
    {
            Instantiate(meleeAttack, player.transform.position, Quaternion.identity, null);
    }
}
