using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Button thisButton;
    public Item thisItem;

    void Start()
    {
        thisButton = GetComponent<Button>();
    }
}
