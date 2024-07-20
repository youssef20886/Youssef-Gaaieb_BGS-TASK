using System;
using UnityEngine;

public class PlayerInteractionsTrigger : MonoBehaviour
{
    public event EventHandler<OnInteractableDetectedEventArgs> OnInteractableDetected;
    public class OnInteractableDetectedEventArgs : EventArgs
    {
        public IInteractable interactable;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            OnInteractableDetected?.Invoke(this, new OnInteractableDetectedEventArgs{
                interactable = interactable
            });
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            OnInteractableDetected?.Invoke(this, new OnInteractableDetectedEventArgs{
                interactable = null
            });
        }
    }
}
