using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _items;

    [SerializeField]
    private GameObject _menuItem;

    /// <summary>
    /// Hide the shop when the exit button is pressed.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);

        // Unselect the Exit button by selecting another one
        GetComponentInChildren<Scrollbar>().Select();
        PlayerMain.Instance.GetComponent<PlayerInput>().enabled = true;
    }

    private void Start()
    {
        var uiGrid = GetComponentInChildren<GridLayoutGroup>();

        _items.Sort((d1, d2) => d1.Id - d2.Id);

        foreach (var item in _items)
        {
            var button = Instantiate(_menuItem, uiGrid.transform, false);
            button.GetComponent<Button>().onClick.AddListener(() => BuyItem(item.Id));

            var image = button.transform.GetChild(0).GetComponent<Image>();
            image.sprite = item.Sprite;

            var nameText = button.transform.GetChild(1);
            var priceText = button.transform.GetChild(2);

            nameText.GetComponent<TMP_Text>().text = item.name;
            priceText.GetComponent<TMP_Text>().text = "$" + item.BuyingPrice;

            var rectTrans = uiGrid.GetComponent<RectTransform>();
            var buttonRect = button.GetComponent<RectTransform>();

            print(buttonRect.rect.height);
            print(Mathf.FloorToInt((float)item.Id / 3) + 1);
            rectTrans.sizeDelta = new Vector2(0f, buttonRect.rect.height * (Mathf.FloorToInt((float)item.Id / 3) + 1));
        }

        // Take one button and select it
        uiGrid.GetComponentInChildren<Button>().Select();
    }

    private void BuyItem(int itemId)
    {
        var data = _items[itemId];
        if (PlayerMain.Instance.Money.TakeMoney(data.BuyingPrice))
        {
            if (!PlayerMain.Instance.Inventory.AddItem(data))
            {
                PlayerMain.Instance.Money.AddMoney(data.BuyingPrice);
            }
        }
    }
}
