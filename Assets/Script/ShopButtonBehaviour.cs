using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// A custom button that has an event OnSelect. Needed for the shop.
/// </summary>
public class ShopButtonBehaviour : Button
{
    /// <summary>
    /// The event being called on select
    /// </summary>
    public event Action OnSelectEvent;

    /// <inheritdoc/>
    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        OnSelectEvent?.Invoke();
    }
}

