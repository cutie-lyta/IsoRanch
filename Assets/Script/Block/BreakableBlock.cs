/// <summary>
/// Define the behaviour for block that can be "broken" (taken back in the inventory.
/// It's implied that the BlockData is a BreakableBlockData
/// But it is supported to pass another type of block data, it just won't do nothing.
/// </summary>
public class BreakableBlock : Block
{
    /// <summary>
    /// Take back the block if empty handed or holding itself already.
    /// </summary>
    /// <param name="ctx"> The context, including the Held Item. </param>
    public override void Action(ActionContext ctx)
    {
        var data = this.Data as BreakableBlockData;

        if (!data)
        {
            return;
        }

        if (ctx.HeldInHand != null && ctx.HeldInHand != data.Item)
        {
            return;
        }

        if (PlayerMain.Instance.Inventory.AddItem(data.Item))
        {
            Destroy(this.gameObject);
        }
    }
}
