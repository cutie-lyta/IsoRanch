using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;

    private Rigidbody _rb;

    private void Start()
    {
        PlayerMain.Instance.InputHandler.Jump += OnJump;
        _rb = GetComponent<Rigidbody>();
    }

    public bool IsGrounded()
    {
        // Player is two in height.
        return Physics.Raycast(this.transform.position, Vector3.down, 1f);
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (obj.performed && IsGrounded())
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
