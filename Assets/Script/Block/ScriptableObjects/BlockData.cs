using UnityEngine;

/// <summary>
/// Contains basic data for a block.
/// </summary>
[CreateAssetMenu(fileName = "Plant1_Block", menuName = "IsoRanch/Block/Generic Block")]
public class BlockData : ScriptableObject
{
    /// <summary>
    /// Gets the name as used in the What Am I Looking At
    /// </summary>
    [field: SerializeField]
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description as used in the What Am I Looking At
    /// </summary>
    [field: SerializeField]
    public string Description { get; private set; }
}
