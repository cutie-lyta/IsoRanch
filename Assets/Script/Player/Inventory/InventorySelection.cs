using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventorySelection : MonoBehaviour
{
    public int Selected { get; private set; }

    private void Start()
    {
        PlayerMain.Instance.InputHandler.InventoryNavigation += OnInventoryNavigation;
        Selected = 0;
        GetComponent<InventoryUI>().InventoryPanel.transform
            .GetChild(Selected).GetComponent<Image>().color = Color.yellow;
    }

    private void OnInventoryNavigation(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            GetComponent<InventoryUI>().InventoryPanel.transform
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

            GetComponent<InventoryUI>().InventoryPanel.transform
                    .GetChild(Selected).GetComponent<Image>().color = Color.yellow;
        }
    }
}
