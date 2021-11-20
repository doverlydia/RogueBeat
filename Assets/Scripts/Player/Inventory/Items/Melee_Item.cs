using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Item : Item
{
    protected override void Ability()
    {
        print(name + "Abilty Activated!");
    }
}
