using UnityEngine;

/// <summary>
/// Data for items that can be placed and spawn block.
/// </summary>
[CreateAssetMenu(fileName = "Plant1", menuName = "IsoRanch/Item/Placeable Item")]
public class PlaceableItemData : ItemData
{
    /// <summary>
    /// Gets the block getting placed down on Action.
    /// </summary>
    [field: SerializeField]
    public GameObject Block { get; private set; }
}
