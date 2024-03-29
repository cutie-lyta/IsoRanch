using UnityEngine;

/// <summary>
/// Define a egg block, that will spawn an Animal
/// </summary>
[CreateAssetMenu(fileName = "Egg1_Block", menuName = "IsoRanch/Block/Egg Block")]
public class EggBlockData : BlockData
{
    /// <summary>
    /// Gets the animal it will spawn after hatching
    /// </summary>
    [field: SerializeField]
    public GameObject Animal { get; private set; }

    /// <summary>
    /// Gets the time it take to hatch
    /// </summary>
    [field: SerializeField]
    public float HatchTime { get; private set; }

    /// <summary>
    /// Gets the number of animals that will spawn at once.
    /// </summary>
    [field: SerializeField]
    public int HatchQuantity { get; private set; }
}
