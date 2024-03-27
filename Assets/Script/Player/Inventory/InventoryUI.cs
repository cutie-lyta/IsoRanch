using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [field: SerializeField]
    public GameObject InventoryPanel { get; private set; }

    private List<TMP_Text> _texts = new ();
    private List<Image> _imgs = new ();

    private void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            var inventoryItem = InventoryPanel.transform.GetChild(i);
            var image = inventoryItem.transform.GetChild(0);
            var number = inventoryItem.transform.GetChild(1);

            _imgs.Add(image.GetComponent<Image>());
            _texts.Add(number.GetComponent<TextMeshProUGUI>());
        }
    }

    private void FixedUpdate()
    {
        int i = 0;
        foreach (var items in PlayerMain.Instance.Inventory.GetItems())
        {
            _texts[i].text = PlayerMain.Instance.Inventory.GetItemAmount(items).ToString();
            _imgs[i].sprite = items.Sprite;
            _imgs[i].color = Color.white;
            i++;
        }

        for (; i < 9; i++)
        {
            _texts[i].text = string.Empty;
            _imgs[i].color = new Color(0, 0, 0, 0);
        }
    }
}
