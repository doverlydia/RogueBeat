using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Shield,
    Projectile
}

public abstract class Item : DungeonObject
{
    public ItemObject itemObj;

    public int beatActivated;
    
    public string itemName;
    public ItemType type;
    [TextArea(15, 20)]
    [SerializeField] private string itemDescription;
    [SerializeField] private int maxActiveTime;
    
    private bool _actionEnabled = false;
    private int _timeActive;
    public bool actionEnabled
    {
        get => _actionEnabled;
        set
        {
            if(value == true)
            {
                Action();
            }
            if (value == false)
            {
                _timeActive = 0;
            }
        }
    }

    private void Action()
    {
        _timeActive++;

        if (_timeActive >= maxActiveTime)
            actionEnabled = false;
        
        Ability();
    }

    protected abstract void Ability();
}
