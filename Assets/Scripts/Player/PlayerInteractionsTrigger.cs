using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractions))]
public class PlayerInteractionsTrigger : MonoBehaviour
{
    PlayerInteractions playerInteractions;

    private void Awake()
    {
        playerInteractions = GetComponent<PlayerInteractions>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            playerInteractions.SetInteractable(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            playerInteractions.ResetInteractable();
        }
    }
}
