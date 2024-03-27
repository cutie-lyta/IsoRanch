using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Shop opening block.
/// </summary>
public class ShopBlock : Block
{
    [SerializeField]
    private Shop _shop;

    /// <inheritdoc />
    protected override void Action(ActionContext ctx)
    {
        _shop.gameObject.SetActive(true);
        PlayerMain.Instance.GetComponent<PlayerInput>().enabled = false;
    }
}
