using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBlock : Block
{
    private PlantBlockData _blockData;

    public void SetBlockData(PlantBlockData data)
    {
        _blockData = data;
    }

    protected override void Action(ActionContext ctx)
    {
        PlayerMain.Instance.Inventory.AddItem(_blockData.Plant, _blockData.HarvestQuantity);
        Destroy(this.gameObject);
    }

    protected override void OnStay(ActionContext ctx)
    {
        if (_blockData.DamageType == DamageType.Continuous)
        {
            // Damage the player
        }
    }

    protected override void OnEnter(ActionContext ctx)
    {
        if (_blockData.DamageType == DamageType.OnEnter)
        {
            // Damage the player
        }
    }

    protected override void OnExit(ActionContext ctx)
    {
        if (_blockData.DamageType == DamageType.OnExit)
        {
            // Damage the player
        }
    }
}
