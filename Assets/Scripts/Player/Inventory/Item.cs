using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public string itemDescription;

    public int amountOwned;
    public int beatActivated;
    public abstract void Action();
}
