using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AutoShooting : Weapon
{
    [SerializeField] GameObject strongBullet;

    [SerializeField] int beatPenalty = 1;
    [SerializeField] int beatPenaltyCounter = 0;
    [SerializeField] bool ableToTap = true;
    [SerializeField] bool tapped = false;

    public GameObject bulletToShoot;

    bool ovverideShootByItem = false;
    bool ovverideSpecialShootByItem = false;


    public override void OnBeat()
    {
        ovverideShootByItem = GameManager.instance.inventory.myActiveItems.Where(item => (item.overideProjectile  == true && item.actionEnabled == true)).Count() > 0;
        ovverideSpecialShootByItem = GameManager.instance.inventory.myActiveItems.Where(item => (item.overideSpecialAbility == true && item.actionEnabled == true)).Count() > 0;
        
        tapped = false;

        if (!ovverideShootByItem)
            currentBullet = Shoot(bullet);

        if (beatPenaltyCounter >= beatPenalty)
        {
            ableToTap = true;
            beatPenaltyCounter = 0;
        }

        if (!ableToTap)
        {
            beatPenaltyCounter++;
        }
    }

    public override bool Shoot()
    {
        bool succesful = false;

        if (currentBullet == null)
            return false;
        if (ableToTap && !tapped)
        {
            if (bpm.okToShoot)
            {
                SpecialAbility();

                succesfulShots++;
                succesful = true;
            }
            else
            {
                bulletToShoot = bullet;
                succesfulShots = 0;
                bpm.beatIndicator.enabled = true;
                ableToTap = false;
            }
            if (!ovverideSpecialShootByItem)
            {
                GameObject obj = Instantiate(bulletToShoot, currentBullet.transform.position, Quaternion.identity, null);
                Destroy(currentBullet);
                currentBullet = obj;

            }
        }
        else
        {
            if (!bpm.okToShoot)
            {
                bpm.beatIndicator.enabled = true;
                ableToTap = false;
                succesfulShots = 0;
            }
        }

        tapped = true;
        return succesful;
    }
    public void SpecialAbility()
    {
        bulletToShoot = strongBullet;
    }
    public GameObject Shoot(GameObject projectile)
    {
        return Instantiate(projectile, player.transform.position, Quaternion.identity);
    }
}
