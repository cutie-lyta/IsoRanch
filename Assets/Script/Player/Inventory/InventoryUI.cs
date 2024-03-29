using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Component that show the UI of the inventory
/// </summary>
public class InventoryUI : MonoBehaviour
{
    /// <summary>
    /// List of text component of the inventory bar, being populated on awake
    /// </summary>
    private readonly List<TMP_Text> _texts = new ();

    /// <summary>
    /// List of image component of the inventory bar, being populated on awake
    /// </summary>
    private readonly List<Image> _imgs = new ();

    /// <summary>
    /// The inventory panel.
    /// </summary>
    [SerializeField]
    private GameObject _inventoryPanel;

    /// <summary>
    /// An handle to the inventory selection component.
    /// </summary>
    private InventorySelection _selection;

    private void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            var inventoryItem = _inventoryPanel.transform.GetChild(i);
            var image = inventoryItem.transform.GetChild(0);
            var number = inventoryItem.transform.GetChild(1);

            _imgs.Add(image.GetComponent<Image>());
            _texts.Add(number.GetComponent<TextMeshProUGUI>());
        }

        _selection = GetComponent<InventorySelection>();
    }

    private void FixedUpdate()
    {
        int i = 0;
        foreach (var items in PlayerMain.Instance.Inventory.GetItems())
        {
            _texts[i].text = PlayerMain.Instance.Inventory.GetItemAmount(items).ToString();
            _imgs[i].sprite = items.Sprite;
            _imgs[i].color = Color.white;

            _inventoryPanel.transform
                .GetChild(i).GetComponent<Image>().color = Color.grey;

            i++;
        }

        for (; i < 9; i++)
        {
            _texts[i].text = string.Empty;
            _imgs[i].color = new Color(0, 0, 0, 0);

            _inventoryPanel.transform
                .GetChild(i).GetComponent<Image>().color = Color.grey;
        }

        _inventoryPanel.transform
            .GetChild(_selection.Selected).GetComponent<Image>().color = Color.yellow;
    }
}
