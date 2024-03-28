using UnityEngine;

/// <summary>
/// Define a plant block.
/// </summary>
[CreateAssetMenu(fileName = "Plant1_Block", menuName = "IsoRanch/Block/Plant Block")]
public class PlantBlockData : BlockData
{
    /// <summary>
    /// Gets the damage type
    /// </summary>
    [field: SerializeField]
    public DamageType DamageType { get; private set; }

    /// <summary>
    /// Gets the amount of damage dealt
    /// </summary>
    [field: SerializeField]
    public float Damage { get; private set; }

    /// <summary>
    /// Gets the plant being given to the player
    /// </summary>
    [field: SerializeField]
    public PlantData Plant { get; private set; }

    /// <summary>
    /// Gets the time it takes to make the plant grows.
    /// </summary>
    [field: SerializeField]
    public float HarvestTime { get; private set; }

    /// <summary>
    /// Gets how many plant are added to the inventory.
    /// </summary>
    [field: SerializeField]
    public int HarvestQuantity { get; private set; }
}
