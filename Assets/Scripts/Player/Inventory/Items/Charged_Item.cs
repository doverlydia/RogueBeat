using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charged_Item : Item
{
    [SerializeField] GameObject chragedAttack;
    protected override void Ability()
    {
        Instantiate(chragedAttack, player.transform.position, Quaternion.identity, null);
    }
}
