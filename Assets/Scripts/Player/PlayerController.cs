using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRenderer))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerInteractions))]
[RequireComponent(typeof(PlayerInventory))]

public class PlayerController : MonoBehaviour
{
    private InputHandler inputHandler;
    private PlayerRenderer playerRenderer;
    private PlayerAnimator playerAnimator;
    private PlayerMovement playerMovement;
    private PlayerInteractions playerInteractions;
    private PlayerInventory playerInventory;


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
        playerInventory.HandleInventory(inputHandler.IsOpenInventoryPressed());
    }


    private void Initialize()
    {
        inputHandler = GetComponent<InputHandler>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInteractions = GetComponent<PlayerInteractions>();   
        playerInventory = GetComponent<PlayerInventory>(); 
    }
}
