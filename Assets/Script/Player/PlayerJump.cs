using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Component that make the player able to jump.
/// </summary>
public class PlayerJump : MonoBehaviour
{
    /// <summary>
    /// The force of the jump.
    /// </summary>
    [SerializeField]
    private float _jumpForce;

    /// <summary>
    /// A Handle to the player's Rigidbody.
    /// </summary>
    private Rigidbody _rb;

    private void Start()
    {
        PlayerMain.Instance.InputHandler.Jump += OnJump;
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Check with a raycast if the player is grounded.
    /// </summary>
    /// <returns> True if the player is on the ground, else false. </returns>
    public bool IsGrounded()
    {
        // Player is two in height.
        return Physics.Raycast(this.transform.position, Vector3.down, 1f);
    }

    /// <summary>
    /// Jump input callback
    /// </summary>
    /// <param name="obj"> The input context. </param>
    private void OnJump(InputAction.CallbackContext obj)
    {
        if (obj.performed && IsGrounded())
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
