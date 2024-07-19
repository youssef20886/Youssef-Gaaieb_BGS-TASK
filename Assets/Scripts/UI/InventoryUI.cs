using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private InventorySlotsCreator inventorySlotsCreator;
    private UiElement inventoryUiElement;
    private List<InventorySlotUI> inventorySlots;
    private InventorySlotUI selectedInventorySlot;


    private void Awake()
    {
        inventorySlotsCreator = GetComponent<InventorySlotsCreator>();
        inventoryUiElement = GetComponentInChildren<UiElement>();
    }

    private void Start()
    {
        inventorySlots = inventorySlotsCreator.CreateInventorySlots(inventory.NumberOfSlots); 

        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.OnSelected += InventorySlotUI_OnSelected;
        }   
    }

    private void OnEnable()
    {
        inventory.OnInventoryUpdate += Inventory_OnInventoryUpdate;
    }

    private void OnDisable()
    {
        inventory.OnInventoryUpdate -= Inventory_OnInventoryUpdate;
    }

    private void InventorySlotUI_OnSelected(object sender, EventArgs e)
    {
        selectedInventorySlot = sender as InventorySlotUI;
        inventory.SetSelectedItem(selectedInventorySlot.GetItem());

        foreach (var inventorySlot in inventorySlots)
        {
            if (inventorySlot != selectedInventorySlot)
            {
                inventorySlot.SetIsSelected(false);
            }
        }
    }

    private void Inventory_OnInventoryUpdate(object sender, Inventory.OnInventoryOpenedEventArgs e)
    {
        if (e.inventoryState)
        {
            UpdateInventoryUI(e.InventoryItems);
            ResetSelectedInventorySlot();
        }
        else
        {
            // ResetSelectedInventorySlot();
        }

        inventoryUiElement.SetActive(e.inventoryState);
    }

    private void UpdateInventoryUI(List<ItemSO> inventoryItems)
    {
        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.ClearSlot();
        }

        foreach (var item in inventoryItems)
        {
            InventorySlotUI emptySlot = inventorySlotsCreator.GetFirstEmptySlot(inventorySlots);

            if(emptySlot != null)
            {
                emptySlot.AddItem(item);
            }
            else
            {
                // inventory is full
                Debug.LogWarning("Inventory is full.");
            }
        }
    }

    private void ResetSelectedInventorySlot()
    {
        if (selectedInventorySlot != null)
        {
            inventory.SetSelectedItem(null);
            selectedInventorySlot.SetIsSelected(false);
            selectedInventorySlot = null;
        }
    }
}
