using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Item : Item
{
    [SerializeField] GameObject homingProjectile;
    protected override void Ability()
    {
        if (player == null)
        {
            player = GameManager.Instance.player;
        }
        if (homingProjectile != null && player != null)
        {
            GameObject obj1 = Instantiate(homingProjectile, player.transform.position, Quaternion.identity);
            GameObject obj2 = Instantiate(homingProjectile, player.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("homing projectile or player is null");
        }
    }
}
