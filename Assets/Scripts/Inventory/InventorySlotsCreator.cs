
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotsCreator : MonoBehaviour
{
    [SerializeField] private GameObject SlotPrefab;
    [SerializeField] private RectTransform slotsParent;

    public List<InventorySlotUI> CreateInventorySlots(int numberOfSlots)
    {
        List<InventorySlotUI> inventorySlots = new List<InventorySlotUI>();

        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject slot = Instantiate(SlotPrefab, slotsParent);
            InventorySlotUI slotUI = slot.GetComponent<InventorySlotUI>();
            slotUI.ClearSlot();
            inventorySlots.Add(slotUI);
        }

        return inventorySlots;
    }

    public InventorySlotUI GetFirstEmptySlot(List<InventorySlotUI> inventorySlots)
    {
        InventorySlotUI emptySlot = null;

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].IsEmpty)
            {
                emptySlot = inventorySlots[i];
                break;
            }
        }

        return emptySlot;
    }
}
