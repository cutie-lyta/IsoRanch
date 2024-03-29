using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Component that let the player act, so effectively harvest.
/// </summary>
public class PlayerHarvest : MonoBehaviour
{
    private void Start()
    {
        PlayerMain.Instance.InputHandler.Action += OnAction;
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
            ActionContext ctx = default;
            ctx.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

            if (PlayerMain.Instance.Selector.IsCurrentBlockInteractable(PlayerMain.Instance.Selector.CurrentUseBlock))
            {
                PlayerMain.Instance.Selector.CurrentUseBlock.gameObject.SendMessage("Action", ctx);
            }
            else
            {
                PlayerMain.Instance.Placer.PlaceItem(ctx);
            }
        }
    }
}
