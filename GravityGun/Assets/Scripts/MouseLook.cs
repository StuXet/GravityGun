using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //You can change the mpuse sensitivity
    [SerializeField] float _mouseSensitivity = 100f;

    public Transform playerBody;

    float _xRotation = 0f;

    //The cursor is locked on start to not be able see the him
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Move the player view direction by your choice  
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

