using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class Inventory : DungeonObject
{
    public List<Item> myActiveItems;
    public GameObject _inventoryScreen;
    public GameObject InventoryScreen
    {
        get => _inventoryScreen;
        set
        {
            _inventoryScreen = value;
            InventoryScreen.GetComponent<_displayInventory>().inventory.Load();
            _inventoryScreen.SetActive(false);
        }
    }
    private int _lastSuccefulShot = 0;

    [HideInInspector] public ItemSlot currentSlot;

    private void Start()
    {
        if (InventoryScreen == null)
        {
            InventoryScreen = FindObjectOfType<_displayInventory>().gameObject;
        }
    }
    public void SlotTap()
    {
        currentSlot = EventSystem.current.currentSelectedGameObject.GetComponent<ItemSlot>();

        if (currentSlot.thisItem == null)
        {
            InventoryScreen.SetActive(true);
        }
        else
        {
            RemoveCurrentItem();
        }
    }

    public void SelectItem()
    {
        Item item = EventSystem.current.currentSelectedGameObject.GetComponent<Item>().itemObj.prefab.GetComponent<Item>(); //getting a reference to the prefab in the project, not the one in the scene which is destroyed when changing scenes.
        GameManager.Instance.inventory.AddItem(item);
        GameManager.Instance.inventory.currentSlot.thisItem = item;
        GameManager.Instance.inventory.currentSlot.thisButton.GetComponentInChildren<TMP_Text>().text = item.itemName;
        GameManager.Instance.inventory.currentSlot = null;

        FindObjectOfType<_displayInventory>().gameObject.SetActive(false);
    }
    public void RemoveCurrentItem()
    {
        myActiveItems.Remove(EventSystem.current.currentSelectedGameObject.GetComponent<ItemSlot>().thisItem);
        currentSlot.thisItem = null;
        currentSlot.thisButton.GetComponentInChildren<TMP_Text>().text = "Item Slot";
    }
    public void AddItem(Item item)
    {
        myActiveItems.Add(item);
    }
    public void RemoveItem(Item item)
    {
        myActiveItems.Remove(item);
    }
    public override void OnBeat()
    {
        if(GameManager.Instance.player.weapon.succesfulShots == 0)
        {
            _lastSuccefulShot = 0;
        }

        foreach (var item in myActiveItems)
        {
            int sucShots = GameManager.Instance.player.weapon.succesfulShots;
            if (sucShots > _lastSuccefulShot && sucShots % item.beatActivated == 0)
            {
                _lastSuccefulShot = sucShots;
                if (item.actionEnabled)
                    item.Action();
                if (item.actionEnabled == false)
                    item.actionEnabled = true;
            }
        }
    }
}
