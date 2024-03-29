using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Component that dispatch the input of the user to the correct action.
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
    public event Action<InputAction.CallbackContext> Movement;

    public event Action<InputAction.CallbackContext> Action;

    public event Action<InputAction.CallbackContext> Jump;

    public event Action<InputAction.CallbackContext> InventoryNavigation;

    private void Start()
    {
        var player = GetComponent<PlayerInput>();
        player.onActionTriggered += InputManager;
    }

    /// <summary>
    /// A switch case that takes in the input and invoke the appropriate event.
    /// </summary>
    /// <param name="ctx"> the input context, contains the action used. </param>
    private void InputManager(InputAction.CallbackContext ctx)
    {
        switch (ctx.action.name)
        {
            case "Movement":
                Movement?.Invoke(ctx);
                break;
            case "Action":
                Action?.Invoke(ctx);
                break;
            case "InventoryNavigation":
                InventoryNavigation?.Invoke(ctx);
                break;
            case "Jump":
                Jump?.Invoke(ctx);
                break;
        }
    }
}
