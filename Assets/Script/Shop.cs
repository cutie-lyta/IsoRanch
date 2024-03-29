using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// The shop class, used to control the shop UI
/// This script has nothing to do with the shop block and can be used standalone.
/// </summary>
public class Shop : MonoBehaviour
{
    [Tooltip("The list of every items that the shop sells.")]
    [SerializeField]
    private List<ItemData> _items;

    [Tooltip("The prefab of one item in the menu, being instantiated for every item in the list above.")]
    [SerializeField]
    private GameObject _menuItem;

    private RectTransform _oldRect;

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

    // Source : https://discussions.unity.com/t/auto-scroll-to-selected-button-in-grid-when-outside-viewport/246277
    public void SnapTo(RectTransform target)
    {
        var uiGrid = GetComponentInChildren<GridLayoutGroup>();

        RectTransform rect = target.gameObject.GetComponent<RectTransform>();

        Vector2 v = rect.position;
        bool inView = RectTransformUtility.RectangleContainsScreenPoint(uiGrid.transform.parent.GetComponent<RectTransform>(), v);

        float incrimentSize = rect.rect.height;

        if (!inView)
        {
            if (_oldRect != null)
            {
                if (_oldRect.localPosition.y < rect.localPosition.y)
                {
                    uiGrid.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -incrimentSize);
                }
                else if (_oldRect.localPosition.y > rect.localPosition.y)
                {
                    uiGrid.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, incrimentSize);
                }
            }
        }

        _oldRect = rect;
    }

    private void OnSelected(GameObject callee)
    {
        SnapTo(callee.GetComponent<RectTransform>());
    }

    private void Start()
    {
        var uiGrid = GetComponentInChildren<GridLayoutGroup>();

        _items.Sort((d1, d2) => d1.Id - d2.Id);

        foreach (var item in _items)
        {
            var button = Instantiate(_menuItem, uiGrid.transform, false);
            var buttonComponent = button.GetComponent<ShopButtonBehaviour>();
            buttonComponent.onClick.AddListener(() => BuyItem(item));
            buttonComponent.OnSelectEvent += () => OnSelected(buttonComponent.gameObject);

            var image = button.transform.GetChild(0).GetComponent<Image>();
            image.sprite = item.Sprite;

            var nameText = button.transform.GetChild(1);
            var priceText = button.transform.GetChild(2);

            nameText.GetComponent<TMP_Text>().text = item.Name;
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

    /// <summary>
    /// Put an item in the Player's inventory and take his money
    /// </summary>
    /// <param name="item"> The item given to the player </param>
    private void BuyItem(ItemData item)
    {
        var data = _items[_items.IndexOf(item)];
        if (PlayerMain.Instance.Money.TakeMoney(data.BuyingPrice))
        {
            if (!PlayerMain.Instance.Inventory.AddItem(data))
            {
                PlayerMain.Instance.Money.AddMoney(data.BuyingPrice);
            }
        }
    }
}
