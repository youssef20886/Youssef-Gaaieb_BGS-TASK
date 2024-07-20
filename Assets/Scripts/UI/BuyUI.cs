using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUI : MonoBehaviour
{
    [SerializeField] UiElement equipButtonUiElement;
    [SerializeField] NpcInventory npcInventory;


    private void OnEnable()
    {
        npcInventory.OnItemSelected += NpcInventory_OnItemSelected;
    }

    private void OnDisable()
    {
        npcInventory.OnItemSelected -= NpcInventory_OnItemSelected;
    }

    private void NpcInventory_OnItemSelected(object sender, Inventory.OnItemSelectedEventArgs e)
    {
        if (e.itemSO is EquippableItemSo)
        {
            equipButtonUiElement.SetActive(true);
        }
        else
        {
            equipButtonUiElement.SetActive(false);
        }
    }
}
