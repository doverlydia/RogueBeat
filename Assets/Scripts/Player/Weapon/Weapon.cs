using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : DungeonObject
{
    public GameObject bullet;
    public GameObject currentBullet;
    protected BPM bpm;
    protected PlayerManager player;
    public int succesfulShots;
    void Start()
    {
        bpm = FindObjectOfType<BPM>();
        player = FindObjectOfType<PlayerManager>();
    }
    public abstract bool Shoot();
}
