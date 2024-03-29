using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// Component that take care of the text shown when changing selected item.
/// </summary>
public class InventoryTextManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private Sequence _curSeq;

    public void ChangeInventory()
    {
        if (PlayerMain.Instance.Inventory.GetHeldItem() != null)
        {
            _text.text = PlayerMain.Instance.Inventory.GetHeldItem().Name;

            if (_curSeq.IsActive())
            {
                _curSeq.Kill();
            }

            Sequence seq = DOTween.Sequence();
            seq
                .Append(_text.DOColor(new Color(1, 1, 1, 1.0f), 0.5f))
                .AppendInterval(2.5f)
                .Append(_text.DOColor(new Color(1, 1, 1, 0.0f), 1.0f));

            _curSeq = seq;
        }
    }

    private void Awake()
    {
        _text.color = new Color(1, 1, 1, 0.0f);
        _curSeq = DOTween.Sequence();
    }
}
