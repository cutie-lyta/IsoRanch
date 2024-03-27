using UnityEngine;

/// <summary>
/// Data that all items abide to
/// Can be derived to have a more option.
/// </summary>
[CreateAssetMenu(fileName = "Seed1", menuName = "IsoRanch/Item/Seed")]
public class SeedData : ItemData
{
    /// <summary>
    /// The crop GameObject
    /// </summary>
    [field: SerializeField]
    public GameObject Crop { get; private set; }
}
