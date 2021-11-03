using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defendable : Progressable
{
    [SerializeField] private float MaxShieldTimer = 0;
    [SerializeField] private GameObject shield;

    private bool isDefending;
    private bool ableToDefend = true;

    internal float currentShieldTimer = 0;
    internal bool IsDefending
    {
        get => isDefending;
        set
        {
            isDefending = value;
            shield?.SetActive(value);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        CurrentValue = MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDefending)
        {
            currentShieldTimer += Time.deltaTime;

            if (currentShieldTimer >= MaxShieldTimer)
            {
                IsDefending = false;
                currentShieldTimer = 0;
            }
        }

        if (!ableToDefend && !isDefending)
        {
            CurrentValue += Time.deltaTime;

            if (CurrentValue >= MaxValue)
            {
                ableToDefend = true;
            }
        }
    }

    public void Defend()
    {
        if (ableToDefend)
        {
            ableToDefend = false;
            IsDefending = true;
            CurrentValue = 0;
            print("Pressed defend");
        }
    }
}
