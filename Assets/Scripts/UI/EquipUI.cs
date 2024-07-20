using System;
using UnityEngine;

public class EquipUI : MonoBehaviour
{
    [SerializeField] UiElement equipButtonUiElement;
    [SerializeField] PlayerInventory playerInventory;


    private void OnEnable()
    {
        playerInventory.OnItemSelected += PlayerInventory_OnItemSelected;
    }

    private void OnDisable()
    {
        playerInventory.OnItemSelected -= PlayerInventory_OnItemSelected;
    }

    private void PlayerInventory_OnItemSelected(object sender, Inventory.OnItemSelectedEventArgs e)
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
