using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    private Vector2 inputDirection;
    private Vector3 movement;

    private void FixedUpdate()
    {
        movement.Set(inputDirection.x, 0, inputDirection.y);
        movement.Normalize();

        var desiredForward = Vector3.RotateTowards(transform.forward, movement, speed * Time.deltaTime, 0f);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            inputDirection = Vector2.zero;
            return;
        }
        inputDirection = context.ReadValue<Vector2>();
    }
}
