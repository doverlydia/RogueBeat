using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _player : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var _item = collision.GetComponent<_item>();
        if (_item != null)
        {
            inventory.AddItem(_item.item, 1);
        }
        Destroy(collision.gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
