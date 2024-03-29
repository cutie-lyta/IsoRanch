using UnityEngine;

/// <summary>
/// Define the behaviour of the Crystal slime, which only go forward.
/// </summary>
public class SlimeBehaviour : AnimalBehaviour
{
    /// <summary>
    /// An handle to the Slime's rigidbody.
    /// </summary>
    private Rigidbody _rb;

    /// <inheritdoc/>
    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Move forward on fixed update, it's the current Slime behaviour.
    /// </summary>
    protected void FixedUpdate()
    {
        _rb.MovePosition(this.transform.position + (Vector3.forward * (5 * Time.fixedDeltaTime)));
    }
}
