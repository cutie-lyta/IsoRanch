using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Keep track of the inventory and publicize methods for managing it.
/// </summary>
[RequireComponent(typeof(InventoryUI))]
[RequireComponent(typeof(InventorySelection))]
public class InventoryManager : MonoBehaviour
{
    public event Action OnSelectionChange;

    /// <summary>
    /// A dictionary of Item and int -> The item and the amount the player possess.
    /// </summary>
    private Dictionary<ItemData, int> _inventory = new ();

    /// <summary>
    /// Handle to the Inventory Selection component
    /// </summary>
    private InventorySelection _selection;

    private ItemData _previouslySelected;

    /// <summary>
    /// Add an item to the inventory dictionnary.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="amount">The amount of items to add.</param>
    /// <returns>True if the inventory could take the item.</returns>
    public bool AddItem(ItemData item, int amount = 1)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory[item] += amount;
            return true;
        }

        if (_inventory.Keys.Count > 9)
        {
            return false;
        }

        _inventory.Add(item, amount);

        return true;
    }

    /// <summary>
    /// Remove an item to the inventory dictionnary and take care of cleanup if you remove all of them.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <param name="amount">The amount of items to remove.</param>
    public void RemoveItem(ItemData item, int amount = 1)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory[item] -= amount;

            if (_inventory[item] <= 0)
            {
                _inventory.Remove(item);
            }
        }
    }

    /// <summary>
    /// Get the number of time you have a specific item
    /// </summary>
    /// <param name="item">The item to count.</param>
    /// <returns>The number of items owned.</returns>
    public int GetItemAmount(ItemData item)
    {
        return _inventory.GetValueOrDefault(item, 0);
    }

    /// <summary>
    /// Get the list of every type of items owned
    /// </summary>
    /// <returns> A list of ItemData you possess. </returns>
    public ItemData[] GetItems()
    {
        return (ItemData[])_inventory.Keys.ToArray().Clone();
    }

    /// <summary>
    /// Get the item held at the time
    /// </summary>
    /// <returns> The ItemData you hold. </returns>
    public ItemData GetHeldItem()
    {
        if (_inventory.Keys.ToArray().Length > _selection.Selected)
        {
            return _inventory.Keys.ToArray()[_selection.Selected];
        }

        return null;
    }

    private void FixedUpdate()
    {
        if (_previouslySelected != GetHeldItem())
        {
            _previouslySelected = GetHeldItem();
            OnSelectionChange?.Invoke();
        }
    }

    private void Awake()
    {
        _selection = GetComponent<InventorySelection>();
    }
}
