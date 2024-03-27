using UnityEngine;

/// <summary>
/// Base class for any block
/// </summary>
public abstract class Block : MonoBehaviour
{
    /// <summary>
    /// The function being called (via SendMessage) when the user presses A and the block is selected;
    /// </summary>
    protected virtual void Action(ActionContext ctx)
    {
    }

    protected virtual void OnEnter(ActionContext ctx)
    {
    }

    protected virtual void OnExit(ActionContext ctx)
    {
    }

    protected virtual void OnStay(ActionContext ctx)
    {
    }
}
