using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Component that take care of Inventory Selection.
/// </summary>
public class InventorySelection : MonoBehaviour
{
    private InventoryTextManager _textManager;

    public int Selected { get; private set; }

    private void Start()
    {
        PlayerMain.Instance.InputHandler.InventoryNavigation += OnInventoryNavigation;
        Selected = 0;

        _textManager = GetComponent<InventoryTextManager>();
    }

    /// <summary>
    /// When the player press the inventory navigation key, it switch the currently held item.
    /// </summary>
    /// <param name="obj"> The input context. </param>
    private void OnInventoryNavigation(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Selected += (int)obj.ReadValue<float>();

            if (Selected >= 9)
            {
                Selected = 0;
            }
            else if (Selected < 0)
            {
                Selected = 8;
            }

            _textManager.ChangeInventory();
        }
    }
}
