using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHarvest))]
[RequireComponent(typeof(PlayerMoney))]
[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(PlayerSelector))]
[RequireComponent(typeof(PlayerSelectorGraphics))]
[RequireComponent(typeof(PlayerDeath))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerMain : MonoBehaviour
{
    public static PlayerMain Instance { get; set; }

    public InventoryManager Inventory { get; set; }

    public PlayerInputHandler InputHandler { get; set; }

    public PlayerMoney Money { get; set; }

    public PlayerSelector Selector { get; set; }

    public PlayerHealth Health { get; set; }

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
        Health = GetComponent<PlayerHealth>();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
