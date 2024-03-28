using UnityEngine;

/// <summary>
/// Represent an item that can be fed to animals, a Plant
/// </summary>
[CreateAssetMenu(fileName = "Plant1", menuName = "IsoRanch/Item/Plant")]
public class PlantData : ItemData
{
    /// <summary>
    /// Gets the type of food the animal will receive.
    /// </summary>
    [field: SerializeField]
    public FoodType FoodType { get; private set; }
}
