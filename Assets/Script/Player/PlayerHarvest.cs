using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Component that let the player act, so effectively harvest.
/// </summary>
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

    /// <summary>
    /// The action input, call Action on the selected block if it is interactive,
    /// else try to place down what you have in hand
    /// </summary>
    /// <param name="obj"> The input context. </param>
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
