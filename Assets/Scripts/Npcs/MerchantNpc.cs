using System;

public class MerchantNpc : Npc, IInteractable
{
    public event EventHandler<OnNpcInteractEventArgs> OnNpcInteract;
    public class OnNpcInteractEventArgs : EventArgs
    {
        public bool isInteracting;
    }
    private NpcInventory npcInventory;
    private PlayerDetecter playerDetecter;
    private bool isInteracting;

    private void Awake()
    {
        npcInventory = GetComponent<NpcInventory>();  
        playerDetecter = GetComponent<PlayerDetecter>();  
    }

    private void OnEnable()
    {
        playerDetecter.OnPlayerDetected += PlayerDetecter_OnPlayerDetected;    
    }

    private void OnDisable()
    {
        playerDetecter.OnPlayerDetected -= PlayerDetecter_OnPlayerDetected;    
    }

    private void PlayerDetecter_OnPlayerDetected(object sender, PlayerDetecter.OnPlayerDetectedEventArgs e)
    {
        // close merchant inventory if player is too far
        if (!e.isClose && npcInventory.GetIsInventoryOpen())
        {
            npcInventory.ToggleInventory();
        }
    }

    public void Interact()
    {
        isInteracting = !isInteracting;
        OnNpcInteract?.Invoke(this, new OnNpcInteractEventArgs{
            isInteracting = isInteracting
        });
        npcInventory.ToggleInventory();
    }

    public NpcInventory GetNpcInventory()
    {
        return npcInventory;
    }

    public bool GetIsInteracting()
    {
        return isInteracting;
    }
}
