using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : Progressable
{
    private void Update()
    {
        if (CurrentValue <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
