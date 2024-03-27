using UnityEngine;

/// <summary>
/// Dirt where the player can place seed on it.
/// </summary>
public class PlowedDirt : Block
{
    /// <inheritdoc />
    protected override void Action(ActionContext ctx)
    {
        var seed = ctx.HeldInHand as SeedData;
        if (seed && this.transform.childCount == 0)
        {
            PlayerMain.Instance.Inventory.RemoveItem(seed);

            Instantiate(seed.Crop, this.transform.position + Vector3.up, this.transform.rotation)
                .transform.SetParent(this.transform);
        }
        else
        {
            if (this.transform.childCount == 1)
            {
                this.transform.GetChild(0).SendMessage("Action", ctx);
            }
        }
    }
}
