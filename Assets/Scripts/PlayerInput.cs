using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed;

    private void Update()
    {
        GetMovementInput();
    }

    private void GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movementInput = new Vector2(horizontalInput, verticalInput);

        OnMovementKeyPressed?.Invoke(movementInput);
    }
}
