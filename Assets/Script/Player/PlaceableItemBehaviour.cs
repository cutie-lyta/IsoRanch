using UnityEngine;

public class PlaceableItemBehaviour : MonoBehaviour
{
    public void PlaceItem(ActionContext ctx)
    {
        var item = ctx.HeldInHand as PlaceableItemData;
        if (item != null)
        {
            var position = PlayerMain.Instance.Selector.CurrentUseBlock.gameObject.transform.position;
            position.y += 1;

            print(transform.rotation.eulerAngles.y + 90);
            print(Math.QuantizeAngle(transform.rotation.eulerAngles.y + 90, 4));
            float quantizedAngle = Math.QuantizeAngle(transform.rotation.eulerAngles.y + 90, 4);

            Instantiate(item.Block, position, Quaternion.Euler(0, quantizedAngle, 0), PlayerMain.Instance.Selector.CurrentUseBlock.gameObject.transform.parent);

            PlayerMain.Instance.Inventory.RemoveItem(ctx.HeldInHand);
        }
    }
}
