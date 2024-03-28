using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventorySelection : MonoBehaviour
{
    private InventoryTextManager _textManager;
    private InventoryUI _ui;

    public int Selected { get; private set; }

    private void Start()
    {
        PlayerMain.Instance.InputHandler.InventoryNavigation += OnInventoryNavigation;
        Selected = 0;
        _ui = GetComponent<InventoryUI>();
        _ui.InventoryPanel.transform
            .GetChild(Selected).GetComponent<Image>().color = Color.yellow;

        _textManager = GetComponent<InventoryTextManager>();
    }

    private void OnInventoryNavigation(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            _ui.InventoryPanel.transform
                .GetChild(Selected).GetComponent<Image>().color = Color.grey;

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

            _ui.InventoryPanel.transform
                    .GetChild(Selected).GetComponent<Image>().color = Color.yellow;
        }
    }
}
