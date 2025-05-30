using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB;
    private Vector3 movementInput;
    public Vector3 movementVector;
    public bool sprinting;
    public bool crouching;
    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputValue input)
    {
        Vector2 newInput = input.Get<Vector2>();

        movementInput = new Vector3(newInput.x, 0, newInput.y);
        Debug.Log("Hej ");
    }

    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
        Debug.Log("då!");
    }

    private void OnSprinting(InputValue input)
    {
        if (!crouching)
        {
            movementSpeed *= 1.25f;
            sprinting = true;
        }
    }

    private void OnSprintingStop(InputValue input)
    {
        if (sprinting)
        {
            movementSpeed *= 0.8f;
            sprinting = false;
        }
    }

    private void OnCrouch(InputValue input)
    {
        if (!sprinting)
        {
            movementSpeed *= 0.5f;
            crouching = true;
        }
    }
    private void OnCrouchStop(InputValue input)
    {
        if (crouching)
        {
            movementSpeed *= 2f;
            crouching = false;
        }
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector3.zero)
        {
            movementVector = movementInput.x * transform.right + movementInput.z * transform.forward;
            movementVector.y = 0;
        }

        characterRB.velocity = movementVector * Time.fixedDeltaTime * movementSpeed;
    }
}
