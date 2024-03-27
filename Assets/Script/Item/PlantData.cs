using UnityEngine;

[CreateAssetMenu(fileName = "Plant1", menuName = "IsoRanch/Item/Plant")]
public class PlantData : ItemData
{
    [field: SerializeField]
    public FoodType FoodType { get; private set; }
}

