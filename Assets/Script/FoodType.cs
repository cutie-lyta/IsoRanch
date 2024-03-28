using System;

/// <summary>
/// Used food type, to nourish other animals
/// Some loves vegetable, some loves fruit, and some can even eat poisonous food.
/// </summary>
[Serializable]
public enum FoodType
{
    /// <summary>
    /// Represents a fruit
    /// </summary>
    Fruit,

    /// <summary>
    /// Represents a vegetable.
    /// </summary>
    Vegetable,

    /// <summary>
    /// Represents a poisonous plant.
    /// </summary>
    Poisonous,
}
