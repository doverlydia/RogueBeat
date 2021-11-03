using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMissleLauncher : DungeonObject
{
    [SerializeField] GameObject missle;

    public override void OnBeat()
    {
        Instantiate(missle, transform.position, Quaternion.identity);
    }
}
