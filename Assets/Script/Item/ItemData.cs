using UnityEngine;

/// <summary>
/// Data that all items abide to
/// Can be derived to have a more option.
/// </summary>
[CreateAssetMenu(fileName = "Item1", menuName = "IsoRanch/Item/Default")]
public class ItemData : ScriptableObject
{
    /// <summary>
    /// Name of the item, as shown in the shop.
    /// </summary>
    [field: SerializeField]
    public string Name { get; private set; }

    /// <summary>
    /// Id of the item, could be useful to implement cheat.
    /// </summary>
    [field: SerializeField]
    public int Id { get; private set; }

    /// <summary>
    /// Buying price of the item, how much does it cost to buy
    /// </summary>
    [field: SerializeField]
    public int BuyingPrice { get; private set; }

    /// <summary>
    /// Selling price of the item, how much do you earn when selling it
    /// </summary>
    [field: SerializeField]
    public int SellingPrice { get; private set; }

    /// <summary>
    /// Sprite of the object, shown everywhere
    /// </summary>
    [field: SerializeField]
    public Sprite Sprite { get; private set; }
}
