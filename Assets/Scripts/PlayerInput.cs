using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private UnityEvent<Vector2> OnMovementKeyPressed;
    [SerializeField] private UnityEvent<Vector2> OnMousePositionChange;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mousePositionInWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition);
        OnMousePositionChange?.Invoke(mousePositionInWorldSpace);
    }

    private void GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movementInput = new Vector2(horizontalInput, verticalInput);

        OnMovementKeyPressed?.Invoke(movementInput);
    }
}
