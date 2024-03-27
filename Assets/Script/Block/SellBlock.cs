using UnityEngine;

public class SellBlock : Block
{
    private bool mode = false;

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

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

    protected override void Action(ActionContext ctx)
    {
        if (ctx.HeldInHand == null)
        {
            mode = !mode;
            ChangeSkin();

            return;
        }

        if (mode)
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
}
