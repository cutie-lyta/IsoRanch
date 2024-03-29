using UnityEngine;

/// <summary>
/// Component that place PlaceableItem on the ground.
/// </summary>
public class PlaceableItemBehaviour : MonoBehaviour
{
    /// <summary>
    /// Called when action if performed on block that can't be interacted with :
    /// It places an item at the CurrentUseBlock position (cf. PlayerSelector) and
    /// Rotate it parallel to the Player to kinda copy Minecraft's behaviour.
    /// It also handle if the item is not placeable by... well... not placing it ?
    /// </summary>
    /// <param name="ctx"> The context of the action. </param>
    public void PlaceItem(ActionContext ctx)
    {
        var item = ctx.HeldInHand as PlaceableItemData;
        if (item != null)
        {
            var position = PlayerMain.Instance.Selector.CurrentUseBlock.gameObject.transform.position;
            position.y += 1;

            float quantizedAngle = Math.QuantizeAngle(transform.rotation.eulerAngles.y + 90, 4);

            Instantiate(item.Block, position, Quaternion.Euler(0, quantizedAngle, 0), PlayerMain.Instance.Selector.CurrentUseBlock.gameObject.transform.parent);

            PlayerMain.Instance.Inventory.RemoveItem(ctx.HeldInHand);
            PlayerMain.Instance.SoundModule.Play("place");
        }
    }
}
