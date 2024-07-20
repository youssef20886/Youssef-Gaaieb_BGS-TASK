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

    public event EventHandler<OnItemSelectedEventArgs> OnItemSelected;
    public class OnItemSelectedEventArgs : EventArgs
    {
        public ItemSO itemSO;
    }

    [SerializeField] protected List<ItemSO> InventoryItems;
    [SerializeField] private int numberOfSlots;
    public int NumberOfSlots 
    {
        get
        {
            return numberOfSlots;
        }
    }

    private bool isInventoryOpen;
    private ItemSO selectedItem;


    public virtual void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        OnInventoryUpdate?.Invoke(this, new OnInventoryOpenedEventArgs{
            InventoryItems = InventoryItems,
            inventoryState = isInventoryOpen
        });
    }

    public void UpdateInventory()
    {
        OnInventoryUpdate?.Invoke(this, new OnInventoryOpenedEventArgs{
            InventoryItems = InventoryItems,
            inventoryState = isInventoryOpen
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

    public void RemoveItem(ItemSO item)
    {
        if (!InventoryItems.Contains(item)) return;

        InventoryItems.Remove(item);
        UpdateInventory();
    }

    public bool IsInventoryOpen()
    {
        return isInventoryOpen;
    }

    public int GetItemPositionInInventory(ItemSO item)
    {
        return InventoryItems.IndexOf(item);
    }


    public void SetSelectedItem(ItemSO item)
    {
        selectedItem = item;

        OnItemSelected?.Invoke(this, new OnItemSelectedEventArgs{
            itemSO = selectedItem,
        });

    }

    public ItemSO GetSelectedItem()
    {
        return selectedItem;
    }
}
