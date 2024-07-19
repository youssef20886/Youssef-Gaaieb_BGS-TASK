using System;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    private MerchantNpc merchantNpc;
    private PlayerDetecter playerDetecter;
    private UiElement InteractUiElement;

    private void Awake()
    {
        merchantNpc = GetComponentInParent<MerchantNpc>();
        playerDetecter = GetComponentInParent<PlayerDetecter>();
        InteractUiElement = GetComponentInChildren<UiElement>();    
    }

    private void OnEnable()
    {
        playerDetecter.OnPlayerDetected += PlayerDetecter_OnPlayerDetected;
        merchantNpc.OnNpcInteract += MerchantNpc_OnNpcInteract;
    }

    private void OnDisable()
    {
        playerDetecter.OnPlayerDetected -= PlayerDetecter_OnPlayerDetected;
        merchantNpc.OnNpcInteract -= MerchantNpc_OnNpcInteract;
    }

    private void MerchantNpc_OnNpcInteract(object sender, MerchantNpc.OnNpcInteractEventArgs e)
    {
        InteractUiElement.SetActive(!e.isInteracting);
    }

    private void PlayerDetecter_OnPlayerDetected(object sender, PlayerDetecter.OnPlayerDetectedEventArgs e)
    {
        InteractUiElement.SetActive(e.isClose);
    }
}
