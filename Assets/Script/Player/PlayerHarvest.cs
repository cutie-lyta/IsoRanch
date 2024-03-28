using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHarvest : MonoBehaviour
{
    private PlayerMain _main;
    private PlaceableItemBehaviour _placeable;

    private void Start()
    {
        _main = GetComponent<PlayerMain>();
        _main.InputHandler.Action += OnAction;
        _placeable = GetComponent<PlaceableItemBehaviour>();
    }

    private void OnAction(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            ActionContext ctx;
            ctx.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

            if (_main.Selector.IsCurrentBlockInteractable(_main.Selector.CurrentUseBlock))
            {
                _main.Selector.CurrentUseBlock.gameObject.SendMessage("Action", ctx);
            }
            else
            {
                _placeable.PlaceItem(ctx);
            }
        }
    }
}
