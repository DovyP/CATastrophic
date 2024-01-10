using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovementDataSO movementData;

    [SerializeField] private float currentVelocity;
    private Vector2 movementDirection;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = currentVelocity * movementDirection.normalized;
    }

    public void MovePlayer(Vector2 movementInput)
    {
        movementDirection = movementInput;
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if(movementInput.magnitude > 0)
        {
            currentVelocity += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= movementData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, movementData.maxSpeed);
    }
}
