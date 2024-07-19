using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInteractions))]
[RequireComponent(typeof(PlayerRenderer))]
[RequireComponent(typeof(PlayerAnimator))]

public class PlayerController : MonoBehaviour
{
    private InputHandler inputHandler;
    private PlayerRenderer playerRenderer;
    private PlayerAnimator playerAnimator;
    private PlayerMovement playerMovement;
    private PlayerInteractions playerInteractions;


    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInteractions = GetComponent<PlayerInteractions>();
    }

    private void Update() 
    {
        playerMovement.ComputeVelocity(inputHandler);
        playerRenderer.FlipPlayer(inputHandler.GetMovementInput());
        playerAnimator.HandleLocomotionAnimations(playerMovement.IsGrounded, playerMovement.VelocityX);
    }
}
