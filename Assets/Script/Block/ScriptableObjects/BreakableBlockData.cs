using UnityEngine;

/// <summary>
/// Define a breakable block, that will give an item back when broken
/// </summary>
[CreateAssetMenu(fileName = "Break1_Block", menuName = "IsoRanch/Block/Breakable Block")]
public class BreakableBlockData : BlockData
{
    /// <summary>
    /// Gets the Item dropped when breaking this block.
    /// </summary>
    [field: SerializeField]
    public ItemData Item { get; private set; }
}
