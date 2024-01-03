using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float speedCharacter;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementCharacter = new Vector3(horizontal, 0.0f, vertical).normalized;

        if(movementCharacter == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movementCharacter);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);

        rb.MovePosition(rb.position + movementCharacter * speedCharacter * Time.deltaTime);
        rb.rotation = targetRotation;
    }
}
