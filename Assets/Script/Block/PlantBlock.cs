/// <summary>
/// Define a grown plant block.
/// Need a PlantBlockData as Data.
/// </summary>
public class PlantBlock : Block
{
    private PlantBlockData _blockData;

    /// <summary>
    /// Get the plant in the inventory
    /// </summary>
    /// <param name="ctx"> The context. Unneeded in that case. </param>
    public override void Action(ActionContext ctx)
    {
        PlayerMain.Instance.Inventory.AddItem(_blockData.Plant, _blockData.HarvestQuantity);
        PlayerMain.Instance.SoundModule.Play("harvest");
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Damage the player if it's the right damage type
    /// </summary>
    /// <param name="ctx"> The context. Unneeded in that case. </param>
    public override void OnStay(ActionContext ctx)
    {
        if (_blockData.DamageType == DamageType.Continuous)
        {
            PlayerMain.Instance.Health.TakeDamage((int)_blockData.Damage);
        }
    }

    /// <summary>
    /// Damage the player if it's the right damage type
    /// </summary>
    /// <param name="ctx"> The context. Unneeded in that case. </param>
    public override void OnEnter(ActionContext ctx)
    {
        if (_blockData.DamageType == DamageType.OnEnter)
        {
            PlayerMain.Instance.Health.TakeDamage((int)_blockData.Damage);
        }
    }

    /// <summary>
    /// Damage the player if it's the right damage type
    /// </summary>
    /// <param name="ctx"> The context. Unneeded in that case. </param>
    public override void OnExit(ActionContext ctx)
    {
        if (_blockData.DamageType == DamageType.OnExit)
        {
            PlayerMain.Instance.Health.TakeDamage((int)_blockData.Damage);
        }
    }

    /// <summary>
    /// Initialize the default block data as PlantBlockData.
    /// There is NO NULL CHECK. It is necessary that the BlockData is PlantBlockData
    /// </summary>
    protected override void Awake()
    {
        _blockData = Data as PlantBlockData;
    }
}
