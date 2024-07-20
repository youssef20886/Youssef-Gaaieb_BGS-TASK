using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradesManager : MonoBehaviour
{
    public event EventHandler OnBuy;
    public event EventHandler OnSell;

    private PlayerInteractions playerInteractions;
    private PlayerInventory playerInventory;
    private NpcInventory npcInventory;

    private void Awake()
    {
        Initialize();    
    }

    private void OnEnable()
    {
        playerInteractions.OnPlayerInteract += PlayerInteractions_OnPlayerInteract;
    }

    private void OnDisable()
    {
        playerInteractions.OnPlayerInteract -= PlayerInteractions_OnPlayerInteract;
    }

    private void PlayerInteractions_OnPlayerInteract(object sender, PlayerInteractions.OnPlayerInteractEventArgs e)
    {
        if (e.interactable is MerchantNpc)
        {
            MerchantNpc merchantNpc = e.interactable as MerchantNpc;
            
            if(e.isInteracting)
            {
                npcInventory = merchantNpc.GetNpcInventory();
            }
            else
            {
                npcInventory = null;
            }

            if (!merchantNpc.GetIsInteracting())
            {
                OpenInventory();
            }
        }
    }

    private void OpenInventory()
    {
        if (!playerInventory.IsInventoryOpen())
        {
            playerInventory.ToggleInventory();
        }
    }

    private void Initialize()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerInteractions = GetComponent<PlayerInteractions>();
    }

    public void Buy()
    {   
        if (playerInventory.IsInventtoryFull()) return;

        ItemSO item = npcInventory.GetSelectedItem();
        
        if (item != null && playerInventory.HasGoldForItem(item))
        {
            // npcInventory.RemoveItem(item);
            OnBuy?.Invoke(this, EventArgs.Empty);
            
            playerInventory.AddItem(item);
            playerInventory.UpdatePlayerGold(-item.price);
        }
    }

    public void Sell()
    {
        if (npcInventory == null) return;

        ItemSO item = playerInventory.GetSelectedItem();

        if (item != null && npcInventory.IsInventoryOpen())
        {
            OnSell?.Invoke(this, EventArgs.Empty);

            playerInventory.RemoveItem(item);
            playerInventory.UpdatePlayerGold(item.price);
        }
    }
}
