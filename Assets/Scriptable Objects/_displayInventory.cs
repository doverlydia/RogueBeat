using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _displayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public Transform inventoryScreen;
    public float x_space_between_items;
    public float y_space_between_items;
    public int number_of_column;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    [SerializeField] GameObject noItemsMessage;

    // Start is called before the first frame update
    void Start()
    {
        if (inventoryScreen == null)
            inventoryScreen = this.transform;

        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
        if (noItemsMessage != null)
            noItemsMessage.SetActive(itemsDisplayed.Count <= 0);
    }
    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, inventoryScreen);
            //obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, inventoryScreen);
                //obj.transform.position = Camera.main.WorldToScreenPoint(GetPosition(i));
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
    //public Vector3 GetPosition(int i) // depricated due to using of grid layout group
    //{
    //    return new Vector3((x_space_between_items * (i % number_of_column) - x_space_between_items * (number_of_column - 1) / 2), (-y_space_between_items *
    //        (i / number_of_column) - y_space_between_items * Mathf.CeilToInt(itemsDisplayed.Count / (number_of_column)) / 2), 0f);
    //}
}
