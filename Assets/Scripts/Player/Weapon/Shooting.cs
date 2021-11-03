using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    BPM bpm;
    [SerializeField] GameObject missle;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weakBullet;
    [SerializeField] GameObject weakMissle;
    public float timer;
    PlayerManager player;
    AutoScope scope;
    Vector2 target;
    [SerializeField] Toggle toggleScope;

    private void Start()
    {
        bpm = FindObjectOfType<BPM>();
        player = FindObjectOfType<PlayerManager>();
        scope = GetComponent<AutoScope>();
    }
    public void Shoot()
    {
        if (bpm.okToShoot)
        {
            if (toggleScope.isOn)
                ScopeShoot(missle);
            else
                Shoot(bullet);
        }
        else
        {
            if (toggleScope.isOn)
                ScopeShoot(weakMissle);
            else
                Shoot(weakBullet);
        }
    }
    public GameObject Shoot(GameObject projectile)
    {
        return Instantiate(projectile, player.transform.position, Quaternion.identity);
    }
    public void ScopeShoot(GameObject missle)
    {
        target = scope.GetClosestTarget();

        if (target != Vector2.zero)
        {
            GameObject pm = Instantiate(missle, player.transform.position, Quaternion.identity);
            pm.GetComponent<PlayerMissle>().targetPos = target;
        }
        else
        {
            toggleScope.isOn = false;
        }
    }

}
