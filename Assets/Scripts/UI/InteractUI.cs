using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private PlayerTriggerCollider playerTriggerCollider;
    [SerializeField] private UiElement InteractUiElement;

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
        bool state = e.interactable == null ? false : true;
        InteractUiElement.SetActive(state);
    }
}
