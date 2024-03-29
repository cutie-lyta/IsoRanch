using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBreak : MonoBehaviour
{
    private void Start()
    {
        PlayerMain.Instance.InputHandler.Break += OnBreak;
    }

    private void OnBreak(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            ActionContext actctx = default;
            actctx.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

            PlayerMain.Instance.Selector.CurrentUseBlock.gameObject.SendMessage("Break", actctx, SendMessageOptions.DontRequireReceiver);
        }
    }
}

