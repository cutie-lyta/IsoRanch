/// <summary>
/// The context passed as parameter for every action
/// </summary>
public struct ActionContext
{
    /// <summary>
    /// Gets or sets the object being held by the Player when acting.
    /// </summary>
    public ItemData HeldInHand { get; set; }
}
