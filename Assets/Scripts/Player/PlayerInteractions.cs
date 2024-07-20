using System;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public event EventHandler<OnPlayerInteractEventArgs> OnPlayerInteract;
    public class OnPlayerInteractEventArgs : EventArgs
    {
        public IInteractable interactable;
        public bool isInteracting;
    }

    private PlayerInteractionsTrigger playerInteractionsTrigger;
    private IInteractable currentInteractable;
    private bool isInteracting;

    private void Awake()
    {
        playerInteractionsTrigger = GetComponent<PlayerInteractionsTrigger>();    
    }

    private void OnEnable()
    {
        playerInteractionsTrigger.OnInteractableDetected += PlayerInteractionsTrigger_OnInteractableDetected; 
    }

    private void OnDisable()
    {
        playerInteractionsTrigger.OnInteractableDetected -= PlayerInteractionsTrigger_OnInteractableDetected; 
    }

    public void HandleInteractions(bool isInteractPressed)
    {
        if (currentInteractable != null  && isInteractPressed)
        {
            CallOnPlayerInteract();
        }
    }

    private void PlayerInteractionsTrigger_OnInteractableDetected(object sender, PlayerInteractionsTrigger.OnInteractableDetectedEventArgs e)
    {
        if (e.interactable is MerchantNpc)
        {
            SetInteractable(e.interactable);
        }
        else
        {
            ResetInteractable();
        }
    }

    private void CallOnPlayerInteract()
    {
        isInteracting = !isInteracting;

        OnPlayerInteract?.Invoke(this, new OnPlayerInteractEventArgs{
            interactable = currentInteractable,
            isInteracting = isInteracting
        });
        currentInteractable.Interact();
    }

    private void SetInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;
    }

    private void ResetInteractable()
    {
        currentInteractable = null;

    }


}
