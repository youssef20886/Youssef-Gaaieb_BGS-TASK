using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float jumpTakeOffSpeed = 7;

    public float GetMovementInput()
    {
        Vector2 movementInput = Vector2.zero;
        return movementInput.x = Input.GetAxisRaw("Horizontal");
    }

    public float HandleJumpInput(Vector2 velocity, bool grounded)
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.S) && !grounded)
        {
            velocity.y = -jumpTakeOffSpeed;
        }
        
        return velocity.y;
    }
}
