using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Vector3 position => rb.position;
    [SerializeField] private float speed, rotationSpeed, gravityStrength;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera mainCam;
    private static PlayerMovements Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        movementPlayer();
       // if(this.gameObject.transform.position.y > 0.6f)
         //   ApplyGravity();
    }

    private void movementPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = mainCam.transform.forward;
        Vector3 camRight = mainCam.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * vertical + camRight * horizontal;

        Vector3.Normalize(moveDirection);

        if (horizontal != 0 && vertical != 0)
        {
            moveDirection *= 0.75f;
        }

        rb.velocity = moveDirection * speed;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (moveDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void ApplyGravity()
    {
        rb.AddForce(Vector3.down * gravityStrength, ForceMode.Acceleration);
    }
}
