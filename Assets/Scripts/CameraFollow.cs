using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerMovements player;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    public Transform target;
    private Vector3 offset;
    [SerializeField] private float batasAtas, batasBawah;

    private void Start()
    {
        offset = target.position - transform.position;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        rotateCamera();
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.position, speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void rotateCamera()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;

        Vector3 targetPosition = target.position - offset;
        transform.position = targetPosition;

        transform.RotateAround(target.position, Vector3.up, horizontal);

        float clampVerticalRotation = transform.rotation.eulerAngles.x - vertical;
        if(clampVerticalRotation > 180f)
        {
            clampVerticalRotation -= 360f;
        }
        clampVerticalRotation = Mathf.Clamp(clampVerticalRotation, -10, 25);
        transform.rotation = Quaternion.Euler(clampVerticalRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.LookAt(target.position);
    }
}
