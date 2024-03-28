using System;

/// <summary>
/// An enumeration of the different damage type an object can have
/// </summary>
[Serializable]
public enum DamageType
{
    /// <summary>
    /// No Damage.
    /// </summary>
    None,

    /// <summary>
    /// Damage on every possible frame.
    /// </summary>
    Continuous,

    /// <summary>
    /// Damage when first colliding
    /// </summary>
    OnEnter,

    /// <summary>
    /// Damage when finished colliding
    /// </summary>
    OnExit,
}
