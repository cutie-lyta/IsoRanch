using UnityEngine;

/// <summary>
/// Dirt where the player can place seed on it.
/// </summary>
public class PlowedDirt : Block
{
    /// <summary>
    /// Gets and sets the current plant being stored on that block.
    /// </summary>
    public GameObject Plant { get; set; }

    /// <inheritdoc />
    public override void Action(ActionContext ctx)
    {
        var seed = ctx.HeldInHand as SeedData;
        if (seed && Plant == null)
        {
            PlayerMain.Instance.Inventory.RemoveItem(seed);

            Plant = Instantiate(seed.Crop, this.transform.position + Vector3.up, this.transform.rotation);
            Plant.transform.SetParent(this.transform);
        }
        else
        {
            if (Plant != null)
            {
                Plant.GetComponent<Block>().Action(ctx);
            }
        }
    }
}
