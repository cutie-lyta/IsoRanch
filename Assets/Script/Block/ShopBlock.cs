using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Shop opening block.
/// </summary>
public class ShopBlock : Block
{
    /// <summary>
    /// An handle to the shop object.
    /// </summary>
    [SerializeField]
    private Shop _shop;

    /// <summary>
    /// An handle to the PlayerInput Unity component.
    /// </summary>
    private PlayerInput _input;

    /// <inheritdoc />
    public override void Action(ActionContext ctx)
    {
        _shop.gameObject.SetActive(true);
        _input.enabled = false;
    }

    private void Start()
    {
        _input = PlayerMain.Instance.GetComponent<PlayerInput>();
    }
}
