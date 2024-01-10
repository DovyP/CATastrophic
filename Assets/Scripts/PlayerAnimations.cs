using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMoveAnimation(bool isMoving)
    {
        animator.SetBool("IsMoving", isMoving);
    }

    public void Animate(float velocity)
    {
        SetMoveAnimation(velocity > 0);
    }
}
