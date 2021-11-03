using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoShooting : Weapon
{
    [SerializeField] GameObject strongBullet;
    [SerializeField] Image beatIndicator;

    private GameObject currentBullet;

    [SerializeField] int beatPenalty = 1;
    [SerializeField] int beatPenaltyCounter = 0;
    [SerializeField] bool ableToTap = true;
    [SerializeField] bool tapped = false;

    [SerializeField] Image movePanel;
    Touch touch;



    public override void OnBeat()
    {
        tapped = false;
        beatIndicator.color = Color.green;

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

    public override void Shoot()
    {
        if (currentBullet == null)
            return;
        if (ableToTap && !tapped)
        {
            if (bpm.okToShoot)
            {
                GameObject obj = Instantiate(strongBullet, currentBullet.transform.position, Quaternion.identity, null);
                Destroy(currentBullet);
                currentBullet = obj;
                succesfulShots++;
            }
            else
            {
                GameObject obj = Instantiate(bullet, currentBullet.transform.position, Quaternion.identity, null);
                Destroy(currentBullet);
                currentBullet = obj;
                succesfulShots = 0;

                beatIndicator.enabled = true;
                beatIndicator.color = Color.red;
                ableToTap = false;
            }
        }
        else
        {
            if (!bpm.okToShoot)
            {
                beatIndicator.enabled = true;
                beatIndicator.color = Color.red;
                ableToTap = false;
                succesfulShots = 0;
            }
        }
        tapped = true;
    }

    public GameObject Shoot(GameObject projectile)
    {
        return Instantiate(projectile, player.transform.position, Quaternion.identity);
    }
}
