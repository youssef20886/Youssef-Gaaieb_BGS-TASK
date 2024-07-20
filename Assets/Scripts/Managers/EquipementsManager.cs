using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipementsManager : MonoBehaviour
{
    [SerializeField] private List<EquippableItemSo> equippedItems;
    [SerializeField] private List<EquipementSlot> equipementSlots = new List<EquipementSlot>();

    private Dictionary<Enums.EquipementType, EquipementSlot> equipmentsDict;

    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();

        GetAllEquipementSlots();
    }

    public void EquipItem()
    {
        EquippableItemSo item = playerInventory.GetSelectedItem() as EquippableItemSo;

        if(item != null)
        {
            int itemIndex = playerInventory.GetItemPositionInInventory(item);
            playerInventory.RemoveItem(item);
            playerInventory.AddItemAtPosition(GetItemToBeSwapped(item.equipementType),itemIndex);
            equippedItems.Add(item);
            GetEquipementSlot(item.equipementType).EquipItem(item);
        }
        
    }

    private void GetAllEquipementSlots()
    {
        equipmentsDict = new Dictionary<Enums.EquipementType,EquipementSlot>();

        foreach (var equipementSlot in GetComponentsInChildren<EquipementSlot>())
        {
            equipmentsDict.Add(equipementSlot.equipementType, equipementSlot);
            equipementSlots.Add(equipementSlot);
            print(equipementSlot.equipementType);
        }
    }

    private EquipementSlot GetEquipementSlot(Enums.EquipementType equipementType)
    {
        return equipmentsDict[equipementType];
    }

    private ItemSO GetItemToBeSwapped(Enums.EquipementType equipementType)
    {
        EquippableItemSo itemToBeSwapped= null;

        foreach (var item in equippedItems)
        {
            if (item.equipementType == equipementType)
            {
                itemToBeSwapped = item;
                break;
            }
        }
        equippedItems.Remove(itemToBeSwapped);
        return itemToBeSwapped;
    }
}
