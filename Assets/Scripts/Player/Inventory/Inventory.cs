using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class Inventory : DungeonObject
{
    public List<GameObject> myItems;
    public List<GameObject> myActiveItems;
    public List<Button> itemSlots;
    private bool _activatedItems;

    private int _lastSuccefulShot = 0;

    private int i = 0;
    public void AddNextItem()
    {
        if (i < myItems.Count)
        {
            myActiveItems.Add(myItems[i]);
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().text = myItems[i].GetComponent<Item>().name;
            i++;
        }
    }
    public void AddItem(GameObject item)
    {
        myActiveItems.Add(item);
    }
    public void RemoveItem(GameObject item)
    {
        myActiveItems.Remove(item);
    }
    public override void OnBeat()
    {
        foreach (var item in myActiveItems)
        {
            Item itemScript = item.GetComponent<Item>();
            int sucShots = GameManager.Instance.player.weapon.succesfulShots;
            if (sucShots > _lastSuccefulShot && sucShots % itemScript.beatActivated == 0)
            {
                _lastSuccefulShot = sucShots;

                if (itemScript.actionEnabled == false)
                    itemScript.actionEnabled = true;
            }
        }
    }
}
