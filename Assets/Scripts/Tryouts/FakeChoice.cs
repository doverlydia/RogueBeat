using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeChoice : MonoBehaviour
{
    BPM bpm;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weakBullet;
    PlayerManager player;

    private void Start()
    {
        bpm = FindObjectOfType<BPM>();
        player = FindObjectOfType<PlayerManager>();
    }
    public void Shoot()
    {
        if (bpm.okToShoot)
        {
            Shoot(bullet);
        }
        else
        {
            Shoot(weakBullet);
        }
    }
    public GameObject Shoot(GameObject projectile)
    {
        return Instantiate(projectile, player.transform.position, Quaternion.identity);
    }
}
