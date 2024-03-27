using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHarvest))]
[RequireComponent(typeof(PlayerMoney))]
[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(PlayerSelector))]
public class PlayerMain : MonoBehaviour
{
    private PlayerHarvest _harvest;
    private PlayerMovement _movement;

    public static PlayerMain Instance { get; set; }

    public InventoryManager Inventory { get; set; }

    public PlayerInputHandler InputHandler { get; set; }

    public PlayerMoney Money { get; set; }

    public PlayerSelector Selector { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;

        Inventory = GetComponent<InventoryManager>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Money = GetComponent<PlayerMoney>();
        Selector = GetComponent<PlayerSelector>();

        _harvest = GetComponent<PlayerHarvest>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
