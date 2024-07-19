using System;
using UnityEngine;

public class PlayerMovement : PhysicsObject
{
    [SerializeField] private float movementSpeed = 7;
    [SerializeField] private float jumpTakeOffSpeed = 9;
    public float VelocityX { get; private set; }
    public bool IsGrounded 
    { 
        get
        {
            return grounded;
        }
    }

    public void ComputeVelocity(InputHandler inputHandler)
    {
        velocity.y = inputHandler.GetJumpInput(velocity, jumpTakeOffSpeed, grounded);
        VelocityX = MathF.Abs(velocity.x) / movementSpeed;
        targetVelocity = new Vector2(inputHandler.GetMovementInput(), 0) * movementSpeed;
    }
}
