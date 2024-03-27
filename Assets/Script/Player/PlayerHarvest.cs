using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHarvest : MonoBehaviour
{

    private void Start()
    {
        PlayerMain.Instance.InputHandler.Action += OnAction;
    }

    private void FixedUpdate()
    {
        ActionContext context;
        context.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

        if (PlayerMain.Instance.Selector.CurrentStandingBlock)
        {
            PlayerMain.Instance.Selector.CurrentStandingBlock.SendMessage("OnStay", context);
        }
    }

    private void OnAction(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            ActionContext context;
            context.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

            PlayerMain.Instance.Selector.CurrentUseBlock.SendMessage("Action", context);
        }
    }
}
