using UnityEngine;

/// <summary>
/// Data for entities, object that can be spawned and can have interaction an behaviour of their own.
/// </summary>
[CreateAssetMenu(fileName = "Entity1", menuName = "IsoRanch/Entity/Generic Entity")]
public class EntityData : ScriptableObject
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

    /// <summary>
    /// Gets the item dropped by the entity, each entity can have its own drop condition
    /// </summary>
    [field: SerializeField]
    public ItemData Drop { get; private set; }

    /// <summary>
    /// Gets the amount of item dropped by the entity
    /// </summary>
    [field: SerializeField]
    public int DropAmount { get; private set; }
}
