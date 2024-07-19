
using System;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public event EventHandler<OnGoldModifiedEventArgs> OnGoldModified;
    public class OnGoldModifiedEventArgs : EventArgs
    {
        public int amount;
    }
    [SerializeField] private int totalGold;
    public int TotalGold 
    {
        get
        { 
            return totalGold;
        }
        set
        {
            totalGold = value;
        } 
    }

    private void Start()
    {
        UpdatePlayerGold(0);    
    }

    public void HandleInventory(bool IsOpenInventoryPressed)
    {
        if (IsOpenInventoryPressed)
        {
            ToggleInventory();
        }
    }

    public void UpdatePlayerGold(int amoun)
    {
        totalGold += amoun;
        OnGoldModified?.Invoke(this, new OnGoldModifiedEventArgs{
            amount = totalGold
        });
    }

    public bool IsInventtoryFull()
    {
        return InventoryItems.Count == NumberOfSlots;
    }

    public bool HasGoldForItem(ItemSO item)
    {
        return totalGold >= item.price;
    }
}
