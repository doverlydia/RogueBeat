using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Progressable : MonoBehaviour
{
    [SerializeField] private float Value = 0;
    [SerializeField] [CanBeNull] private Slider progressBar;

    private float maxValue = 1;
    private float currentValue = 1;
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
    private void Awake()
    {
        MaxValue = Value;
        CurrentValue = Value;
    }
}
