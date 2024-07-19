using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void HandleLocomotionAnimations(bool grounded, float velocityX)
    {
        if (animator)
        {
            SetGroundedAnimation(grounded);
            SetMovementAnimation(velocityX);
        }
        else
        {
            Debug.LogError("No Child Animator Found");
        }

    }

    private void SetMovementAnimation(float velocityX)
    {
        animator.SetFloat("velocityX", velocityX);
    }

    private void SetGroundedAnimation(bool grounded)
    {
        animator.SetBool("grounded", grounded);
    }
}
