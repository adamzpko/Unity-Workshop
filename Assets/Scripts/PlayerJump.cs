using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector3 jumpVector;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnJump(InputValue input)
    {
        if (canJump)
        {
            jumpVector = new Vector3(0, 1, 0);
        }

        Debug.Log("Jumped");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
            jumpVector = Vector3.zero;
        }

        rb.velocity += jumpVector * jumpForce * Time.fixedDeltaTime;
    }
}
