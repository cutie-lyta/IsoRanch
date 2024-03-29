using UnityEngine;

/// <summary>
/// The behaviour of the block for selling items.
/// </summary>
public class SellBlock : Block
{
    /// <summary>
    /// The mode of the selling block :
    /// True sell everything in bulk
    /// False sell one item at a time.
    /// </summary>
    private bool _mode;
    private MeshRenderer _renderer;

    /// <summary>
    /// Sell items according to the block's mode. or change mode if the hand is empty.
    /// </summary>
    /// <param name="ctx"> The context, contains the held item that will be sold. </param>
    public override void Action(ActionContext ctx)
    {
        if (ctx.HeldInHand == null)
        {
            _mode = !_mode;
            ChangeSkin();

            return;
        }

        if (_mode)
        {
            int num = PlayerMain.Instance.Inventory.GetItemAmount(ctx.HeldInHand);
            PlayerMain.Instance.Money.AddMoney(ctx.HeldInHand.SellingPrice * num);
            PlayerMain.Instance.Inventory.RemoveItem(ctx.HeldInHand, num);
        }
        else
        {
            PlayerMain.Instance.Inventory.RemoveItem(ctx.HeldInHand);
            PlayerMain.Instance.Money.AddMoney(ctx.HeldInHand.SellingPrice);
        }
    }

    protected override void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        base.Awake();
    }

    /// <summary>
    /// Change the selling module's Skin according to its mode
    /// For now : Red = Sell One.
    ///           Purple = Sell in Bulk.
    /// </summary>
    private void ChangeSkin()
    {
        // Invert RGB to change color for now
        var materials = _renderer.materials;
        materials[0].color = new Color(
            materials[0].color.b,
            materials[0].color.g,
            materials[0].color.r);
        _renderer.materials = materials;
    }
}
