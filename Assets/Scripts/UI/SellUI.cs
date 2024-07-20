using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellUI : MonoBehaviour
{
    [SerializeField] UiElement sellButtonUiElement;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] PlayerInteractions playerInteractions;

    private bool itemIsSelected;
    private bool canSell;

    private void OnEnable()
    {
        playerInventory.OnItemSelected += PlayerInventory_OnItemSelected;
        playerInteractions.OnPlayerInteract += PlayerInteractions_OnPlayerInteract;
    }

    private void OnDisable()
    {
        playerInventory.OnItemSelected -= PlayerInventory_OnItemSelected;
        playerInteractions.OnPlayerInteract -= PlayerInteractions_OnPlayerInteract;
    }

    private void PlayerInventory_OnItemSelected(object sender, Inventory.OnItemSelectedEventArgs e)
    {
        itemIsSelected = e.itemSO != null;

        if(canSell)
        {
            sellButtonUiElement.SetActive(itemIsSelected);
        }
    }

    private void PlayerInteractions_OnPlayerInteract(object sender, PlayerInteractions.OnPlayerInteractEventArgs e)
    {
        canSell = e.isInteracting ? true : false;

        if (itemIsSelected)
        {
            sellButtonUiElement.SetActive(canSell);
        }

    }
}
