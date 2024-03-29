using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButtonBehaviour : Button
{
    public event Action OnSelectEvent;

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        OnSelectEvent?.Invoke();
    }
}

