using UnityEngine;

/// <summary>
/// Base class for any block
/// </summary>
public abstract class Block : Selectable
{
    [field: SerializeField]
    public BlockData Data { get; private set; }

    /// <summary>
    /// The function being called (via SendMessage) when the user walk on a block;
    /// </summary>
    /// <param name="ctx">
    /// The context of the action, to pass parameters using game elements.
    /// </param>
    public virtual void OnEnter(ActionContext ctx)
    {
    }

    /// <summary>
    /// The function being called (via SendMessage) when the user leaves a block;
    /// </summary>
    /// <param name="ctx">
    /// The context of the action, to pass parameters using game elements.
    /// </param>
    public virtual void OnExit(ActionContext ctx)
    {
    }

    /// <summary>
    /// The function being called (via SendMessage) when the user stay on a block;
    /// </summary>
    /// <param name="ctx">
    /// The context of the action, to pass parameters using game elements.
    /// </param>
    public virtual void OnStay(ActionContext ctx)
    {
    }

    /// <summary>
    /// Base initialization -> Set the name and description for What Am I Looking At.
    /// </summary>
    protected virtual void Awake()
    {
        Name = Data.Name;
        Description = Data.Description;
    }
}
