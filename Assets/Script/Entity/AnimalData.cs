using JetBrains.Annotations;
using UnityEngine;

/// <summary>
/// A type of entity that can be fed and be Shiny (different material)
/// </summary>
[CreateAssetMenu(fileName = "Animal1", menuName = "IsoRanch/Entity/Animal Entity")]
public class AnimalData : EntityData
{
    /// <summary>
    /// Gets the health point of the entity
    /// </summary>
    [field: SerializeField]
    public int Health { get; private set; }

    /// <summary>
    /// Gets the food type the entity can eat
    /// </summary>
    [field: SerializeField]
    public FoodType FoodType { get; private set; }

    /// <summary>
    /// Gets the food prefered by the animal.
    /// If given to them, it doubles their drop amount.
    /// </summary>
    [CanBeNull]
    [field: SerializeField]
    public PlantData FavoriteFood { get; private set; }

    /// <summary>
    /// Gets the material of the Shiny animal
    /// </summary>
    [field: SerializeField]
    public Material ShinyMaterial { get; private set; }
}
