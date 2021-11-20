using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CooldownShooting : Weapon
{
    [SerializeField] private float Value = 0;
    [SerializeField] [CanBeNull] private Slider progressBar;

    private float maxValue = 3;
    private float currentValue = 0;

    [SerializeField] bool tapped = false;
    [SerializeField] Image movePanel;
    Touch touch;

    internal float MaxValue
    {
        get => maxValue;
        set
        {
            maxValue = value;

            if (progressBar != null)
                progressBar.maxValue = value;
        }
    }
    internal float CurrentValue
    {
        get => currentValue;
        set
        {
            currentValue = value;

            if (progressBar != null)
                progressBar.value = value;
        }
    }

    private void Start()
    {
        bpm = FindObjectOfType<BPM>();
        player = FindObjectOfType<PlayerManager>();
        MaxValue = Value;
        CurrentValue = Value;
        print("name: " + progressBar);
    }
    public override bool Shoot()
    {
        bool succesful = false;

        if (bpm.okToShoot && !tapped && CurrentValue >= MaxValue)
        {
            Shoot(bullet);
            succesful = true;
            succesfulShots++;
        }
        else
        {
            if (!bpm.okToShoot)
            {
                CurrentValue = 0;
                bpm.beatIndicator.enabled = true;
                bpm.beatIndicator.color = Color.red;
                succesfulShots = 0;
            }
        }
        tapped = true;
        return succesful;
    }

    public override void OnBeat()
    {
        bpm.beatIndicator.color = Color.green;
        tapped = false;

        if (CurrentValue < MaxValue)
        {
            CurrentValue += 1;
        }
    }

    public GameObject Shoot(GameObject projectile)
    {
        return Instantiate(projectile, player.transform.position, Quaternion.identity);
    }

}
