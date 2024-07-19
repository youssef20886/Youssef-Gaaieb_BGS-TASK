using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollider : MonoBehaviour
{
    public event EventHandler<OnPlayerSetInteractableEventArgs> OnPlayerSetInteractable;
    public class OnPlayerSetInteractableEventArgs : EventArgs
    {
        public IInteractable interactable;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            OnPlayerSetInteractable?.Invoke(this, new OnPlayerSetInteractableEventArgs{
                interactable = interactable
            });
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            OnPlayerSetInteractable?.Invoke(this, new OnPlayerSetInteractableEventArgs{
                interactable = null
            });
        }
    }
}
