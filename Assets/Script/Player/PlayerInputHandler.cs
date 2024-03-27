using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
    public event Action<InputAction.CallbackContext> Movement;

    public event Action<InputAction.CallbackContext> Action;

    public event Action<InputAction.CallbackContext> InventoryNavigation;

    private void Start()
    {
        var player = GetComponent<PlayerInput>();
        player.onActionTriggered += InputManager;
    }

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
        }
    }
}
