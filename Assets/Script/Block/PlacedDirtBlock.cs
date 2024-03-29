using UnityEngine;

/// <summary>
/// The specific placed behaviour of plowed dirt,
/// for dirt block that has been placed down by the Player, and not natural one.
/// </summary>
public class PlacedDirtBlock : BreakableBlock
{
    /// <summary>
    /// If there is no plant growing/grown on that block, execute the take back block routine from the BreakableBlock
    /// </summary>
    /// <param name="ctx"> The context. </param>
    public override void Action(ActionContext ctx)
    {
        if (this.GetComponent<PlowedDirt>().Plant == null)
        {
            base.Action(ctx);
        }
    }

    /// <summary>
    /// Init the block, check if the one underneath is a Stone block,
    /// 'cause I don't want any other block hosting a Dirt block
    /// If not, it destroys itself and give itself back to the Player.
    /// </summary>
    protected override void Awake()
    {
        if (Physics.Raycast(this.transform.position, Vector3.down * 2, out RaycastHit hit))
        {
            if (hit.transform.GetComponent<Block>().Data.Name != "Stone")
            {
                var data = this.Data as BreakableBlockData;
                if (data != null)
                {
                    PlayerMain.Instance.Inventory.AddItem(data.Item);
                }

                Destroy(this.gameObject);
            }
        }
    }
}
