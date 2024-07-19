using System;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public event EventHandler<OnPlayerInteractEventArgs> OnPlayerInteract;
    public class OnPlayerInteractEventArgs : EventArgs
    {
        public IInteractable interactable;
    }

    private IInteractable currentInteractable;

    private void CallOnPlayerInteract()
    {
        OnPlayerInteract?.Invoke(this, new OnPlayerInteractEventArgs{
            interactable = currentInteractable
        });
        currentInteractable.Interact();
    }

    public void ResetInteractable()
    {
        currentInteractable = null;

    }

    public void HandleInteractions(bool isInteractPressed)
    {
        if (currentInteractable != null  && isInteractPressed)
        {
            CallOnPlayerInteract();
        }
    }

    public void SetInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;
    }

}
