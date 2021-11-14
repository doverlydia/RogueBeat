using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    protected override void Ability()
    {
        ParticleSystem part = FindObjectOfType<ParticleSystem>();
        if (part != null)
            part.Play();
    }
}
