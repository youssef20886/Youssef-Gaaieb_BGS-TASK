using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    public event EventHandler<OnInventoryOpenedEventArgs> OnInventoryUpdate;
    public class OnInventoryOpenedEventArgs : EventArgs
    {
        public List<ItemSO> InventoryItems;
        public bool inventoryState;
    }
    [SerializeField] protected List<ItemSO> InventoryItems;
    [SerializeField] private int numberOfSlots;
    private bool inventoryState;
    private ItemSO selectedItem;

    public int NumberOfSlots 
    {
        get
        {
            return numberOfSlots;
        }
    }

    public virtual void ToggleInventory()
    {
        inventoryState = !inventoryState;

        OnInventoryUpdate?.Invoke(this, new OnInventoryOpenedEventArgs{
            InventoryItems = InventoryItems,
            inventoryState = inventoryState
        });
    }

    public void UpdateInventory()
    {
        OnInventoryUpdate?.Invoke(this, new OnInventoryOpenedEventArgs{
            InventoryItems = InventoryItems,
            inventoryState = inventoryState
        });
    }

    public void AddItem(ItemSO item)
    {
        InventoryItems.Add(item);
        UpdateInventory();
    }

    public void AddItemAtPosition(ItemSO item, int index = 0)
    {
        InventoryItems.Insert(index, item);
        UpdateInventory();
    }

    public int GetItemPositionInInventory(ItemSO item)
    {
        return InventoryItems.IndexOf(item);
    }

    public void RemoveItem(ItemSO item)
    {
        if (!InventoryItems.Contains(item)) return;

        InventoryItems.Remove(item);
        UpdateInventory();
    }

    public bool IsInventoryOpen()
    {
        return inventoryState;
    }

    public void SetSelectedItem(ItemSO item)
    {
        selectedItem = item;
    }

    public ItemSO GetSelectedItem()
    {
        return selectedItem;
    }
}
