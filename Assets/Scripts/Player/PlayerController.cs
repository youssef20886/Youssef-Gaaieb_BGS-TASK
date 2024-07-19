using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(PlayerRenderer))]
[RequireComponent(typeof(PlayerAnimator))]

public class PlayerController : PhysicsObject
{
    public float maxSpeed = 7;
    private InputHandler inputHandler;
    private PlayerRenderer playerRenderer;
    private PlayerAnimator playerAnimator;
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    protected override void ComputeVelocity()
    {

        velocity.y = inputHandler.HandleJumpInput(velocity, grounded);

        playerRenderer.FlipPlayer(inputHandler.GetMovementInput());

        float velocityX = MathF.Abs(velocity.x) / maxSpeed;
        playerAnimator.HandleLocomotionAnimations(grounded, velocityX);

        targetVelocity = new Vector2(inputHandler.GetMovementInput(), 0) * maxSpeed;
    }
}
