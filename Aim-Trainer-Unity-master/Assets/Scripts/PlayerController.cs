using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform cameraHolder;
    [SerializeField] float mouseSensitivity = 1;
    [SerializeField] float controllerSensitivity = 1; // Sensitivity for VR controller input

    float verticalLookRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Timer.GameEnded)
            return;

        // Check for VR controller input
        float mouseX = Input.GetAxisRaw("Mouse X");
        if (Mathf.Approximately(mouseX, 0f))
        {
            // If there's no mouse input, use VR controller input
            mouseX = Input.GetAxisRaw("XRControllerHorizontal") * controllerSensitivity;
        }

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);

        float mouseY = Input.GetAxisRaw("Mouse Y");
        if (Mathf.Approximately(mouseY, 0f))
        {
            // If there's no mouse input, use VR controller input
            mouseY = Input.GetAxisRaw("XRControllerVertical") * controllerSensitivity;
        }

        verticalLookRotation -= mouseY * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }
}