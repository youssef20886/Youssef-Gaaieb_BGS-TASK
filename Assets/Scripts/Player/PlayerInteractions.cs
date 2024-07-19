using System;
using UnityEngine;

[RequireComponent(typeof(PlayerTriggerCollider))]
public class PlayerInteractions : MonoBehaviour
{
    public event EventHandler OnPlayerInteract;
    private IInteractable interactable;
    private PlayerTriggerCollider playerTriggerCollider;

    private void Awake()
    {
        playerTriggerCollider = GetComponent<PlayerTriggerCollider>();        
    }

    private void OnEnable()
    {
        playerTriggerCollider.OnPlayerSetInteractable += PlayerTriggerCollider_OnPlayerSetInteractable;
    }

    private void OnDisable()
    {
        playerTriggerCollider.OnPlayerSetInteractable -= PlayerTriggerCollider_OnPlayerSetInteractable;
    }

    private void PlayerTriggerCollider_OnPlayerSetInteractable(object sender, PlayerTriggerCollider.OnPlayerSetInteractableEventArgs e)
    {
        interactable = e.interactable;
    }

    private void CallOnPlayerInteract()
    {
        interactable.Interact();
        OnPlayerInteract?.Invoke(this, new EventArgs());
    }

    public void HandleInteractions(bool canInteract)
    {
        if (interactable != null  && canInteract)
        {
            CallOnPlayerInteract();
        }
    }

}
