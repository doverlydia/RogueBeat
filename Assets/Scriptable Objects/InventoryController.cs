using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var _item = collision.GetComponent<_item>();
        if (_item != null)
        {
            inventory.AddItem(_item.item, 1);
            inventory.Save();
        }
        Destroy(collision.gameObject);
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
