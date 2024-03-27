using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(InventoryUI))]
[RequireComponent(typeof(InventorySelection))]
public class InventoryManager : MonoBehaviour
{
    private Dictionary<ItemData, int> _inventory = new ();

    private InventorySelection _selection;

    private void Awake()
    {
        _selection = GetComponent<InventorySelection>();
    }

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

    public bool RemoveItem(ItemData item, int amount = 1)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory[item] -= amount;

            if (_inventory[item] <= 0)
            {
                _inventory.Remove(item);
            }

            return true;
        }

        return false;
    }

    public int GetItemAmount(ItemData item)
    {
        return _inventory.GetValueOrDefault(item, 0);
    }

    public ItemData[] GetItems()
    {
        return (ItemData[])_inventory.Keys.ToArray().Clone();
    }

    public ItemData GetHeldItem()
    {
        if (_inventory.Keys.ToArray().Length > _selection.Selected)
        {
            return _inventory.Keys.ToArray()[_selection.Selected];
        }

        return null;
    }
}