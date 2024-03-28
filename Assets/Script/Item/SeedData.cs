using UnityEngine;

/// <summary>
/// Data for a seed item, that can be placed on a Plowed Dirt block.
/// </summary>
[CreateAssetMenu(fileName = "Seed1", menuName = "IsoRanch/Item/Seed")]
public class SeedData : ItemData
{
    /// <summary>
    /// Gets the crop GameObject
    /// </summary>
    [field: SerializeField]
    public GameObject Crop { get; private set; }
}
