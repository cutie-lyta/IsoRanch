using UnityEngine;

/// <summary>
/// Base class for every object that can be selected and interacted with.
/// </summary>
public abstract class Selectable : MonoBehaviour
{
    /// <summary>
    /// Gets or sets the name of the object, as shown in the What Am I Looking At.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Gets or sets the description of the object, as shown in the What Am I Looking At
    /// </summary>
    public string Description { get; protected set; }

    /// <summary>
    /// The function being called (via SendMessage) when the user presses A and the block is selected;
    /// </summary>
    /// <param name="ctx">
    /// The context of the action, to pass parameters using game elements.
    /// </param>
    public virtual void Action(ActionContext ctx)
    {
    }
}
