using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Component that let the player move.
/// </summary>
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Player's speed
    /// </summary>
    [SerializeField]
    private float _speed = 5.0F;

    /// <summary>
    /// The current walking direction.
    /// </summary>
    private Vector3 _dir;

    /// <summary>
    /// A handle to the Rigidbody.
    /// </summary>
    private Rigidbody _rb;

    private void Start()
    {
        PlayerMain.Instance.InputHandler.Movement += OnMovement;

        _dir = Vector3.zero;

        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Move towards _dir -> it's Vector3.zero if no input is touched.
    /// </summary>
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (_dir * (_speed * Time.fixedDeltaTime)));
        if (_dir != Vector3.zero)
        {
            _rb.MoveRotation(Quaternion.LookRotation(_dir, Vector3.up));
        }
    }

    /// <summary>
    /// Change _dir according to the input
    /// </summary>
    /// <param name="obj"> The input context - Contains the directional vector </param>
    private void OnMovement(InputAction.CallbackContext obj)
    {
        var value = obj.ReadValue<Vector2>();
        _dir = new Vector3(value.x, 0, value.y);
    }
}
