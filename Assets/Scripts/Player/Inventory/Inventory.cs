using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : DungeonObject
{
    [SerializeField] GameManager manager;
    PlayerManager player;
    public List<GameObject> myItems;

    public void AddItem(GameObject item)
    {
        myItems.Add(item);
    }
    public void RemoveItem(GameObject item)
    {
        myItems.Remove(item);
    }
    public override void OnBeat()
    {
        foreach (var item in myItems)
        {
            Item itemScript = item.GetComponent<Item>();
            if (GameManager.Instance.player.weapon.succesfulShots > 0 && itemScript.beatActivated % GameManager.Instance.player.weapon.succesfulShots == 0)
            {
                itemScript.Action();
            }
        }
    }
}
