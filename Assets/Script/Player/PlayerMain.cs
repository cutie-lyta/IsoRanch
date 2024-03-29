using UnityEngine;

/// <summary>
/// Component and Singleton that connect all of the player together
/// </summary>
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHarvest))]
[RequireComponent(typeof(PlayerMoney))]
[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(PlayerSelector))]
[RequireComponent(typeof(PlayerSelectorGraphics))]
[RequireComponent(typeof(PlayerDeath))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(SoundModule))]
public class PlayerMain : MonoBehaviour
{
    /// <summary>
    /// Gets the static handle to itself.
    /// </summary>
    public static PlayerMain Instance { get; private set; }

    /// <summary>
    /// Gets the handle to the Inventory manager.
    /// </summary>
    public InventoryManager Inventory { get; private set; }

    /// <summary>
    /// Gets the handle to the input handler
    /// </summary>
    public PlayerInputHandler InputHandler { get; private set; }

    /// <summary>
    /// Gets the handle to the Money manager.
    /// </summary>
    public PlayerMoney Money { get; private set; }

    /// <summary>
    /// Gets the handle to the Selected blocks
    /// </summary>
    public PlayerSelector Selector { get; private set; }

    /// <summary>
    /// Gets the handle to the health.
    /// </summary>
    public PlayerHealth Health { get; private set; }

    public SoundModule SoundModule { get; private set; }

    public PlaceableItemBehaviour Placer { get; private set; }

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
        SoundModule = GetComponent<SoundModule>();
        Placer = GetComponent<PlaceableItemBehaviour>();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
