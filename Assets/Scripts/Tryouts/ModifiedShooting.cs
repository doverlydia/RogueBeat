using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifiedShooting : MonoBehaviour
{
    BPM bpm;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletDamageModifier = 1;
    private float _damageMod = 1;
    PlayerManager player;
    [SerializeField] private TMP_Text strength;

    private void Start()
    {
        bpm = FindObjectOfType<BPM>();
        player = FindObjectOfType<PlayerManager>();
        _damageMod = bulletDamageModifier;
    }

    public void Shoot()
    {
        if (bpm.okToShoot)
        {
            bulletDamageModifier += _damageMod;
        }
        else
        {
            bulletDamageModifier = _damageMod;
        }

        strength.text = bulletDamageModifier.ToString();
        Shoot(bullet).GetComponent<Bullet>().damage *= bulletDamageModifier;
    }

    public GameObject Shoot(GameObject projectile)
    {
        return Instantiate(projectile, player.transform.position, Quaternion.identity);
    }
}
