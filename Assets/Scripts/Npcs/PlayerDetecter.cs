using System;
using UnityEngine;

public class PlayerDetecter : MonoBehaviour
{
    public event EventHandler<OnPlayerDetectedEventArgs> OnPlayerDetected;
    public class OnPlayerDetectedEventArgs : EventArgs
    {
        public bool isClose;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CallOnPlayerDetected(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CallOnPlayerDetected(false);
        }
    }

    private void CallOnPlayerDetected(bool state)
    {
        OnPlayerDetected?.Invoke(this, new OnPlayerDetectedEventArgs{
            isClose = state
        });
    }
}
