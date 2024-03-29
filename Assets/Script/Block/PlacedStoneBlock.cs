using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedStoneBlock : BreakableBlock
{
    public override void Action(ActionContext ctx)
    {
        if (ctx.HeldInHand == null)
        {
            base.Action(ctx);
        }
        else
        {
            PlayerMain.Instance.Placer.PlaceItem(ctx);
        }
    }
}
