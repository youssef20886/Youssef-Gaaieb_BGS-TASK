using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRenderer))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerInteractions))]

public class PlayerController : MonoBehaviour
{
    private InputHandler inputHandler;
    private PlayerRenderer playerRenderer;
    private PlayerAnimator playerAnimator;
    private PlayerMovement playerMovement;
    private PlayerInteractions playerInteractions;


    private void Awake()
    {
       Initialize(); 
    }

    private void Update() 
    {
        playerMovement.ComputeVelocity(inputHandler);
        playerRenderer.FlipPlayer(inputHandler.GetMovementInput());
        playerAnimator.SetLocomotionAnimations(playerMovement.IsGrounded, playerMovement.VelocityX);
        playerInteractions.HandleInteractions(inputHandler.IsInteractPressed());
    }


    private void Initialize()
    {
        inputHandler = GetComponent<InputHandler>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInteractions = GetComponent<PlayerInteractions>();    
    }
}
