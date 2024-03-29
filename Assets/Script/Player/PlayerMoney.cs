using TMPro;
using UnityEngine;

/// <summary>
/// Component that keep track of the player's Money.
/// </summary>
public class PlayerMoney : MonoBehaviour
{
    /// <summary>
    /// Money limit for the player.
    /// </summary>
    [SerializeField]
    private int _limit;

    /// <summary>
    /// Money text box.
    /// </summary>
    [SerializeField]
    private TMP_Text _moneyUI;

    /// <summary>
    /// Cheat let you buy things without any money getting taken away
    /// </summary>
    [SerializeField]
    private bool _cheatMode;

    /// <summary>
    /// The current player's bank account.
    /// </summary>
    private int _money;

    /// <summary>
    /// Add money to the player's bank.
    /// </summary>
    /// <param name="amount"> The number of dollar (well, I guess they are dollars) added. </param>
    public void AddMoney(int amount)
    {
        if (_money < _limit)
        {
            _money += amount;
            _moneyUI.text = "$" + _money;
            PlayerMain.Instance.SoundModule.Play("sell");
        }
    }

    /// <summary>
    /// Take money away from the player
    /// </summary>
    /// <param name="amount"> The number of dollar taken away from the player </param>
    /// <returns> True if the transaction worked. </returns>
    public bool TakeMoney(int amount)
    {
        if ((_cheatMode ? 0 : (_money - amount)) >= 0)
        {
            _money -= _cheatMode ? 0 : amount;
            _moneyUI.text = "$" + _money;
            PlayerMain.Instance.SoundModule.Play("buy");
            return true;
        }

        return false;
    }

    private void Awake()
    {
        // Load Money from Savefile (When savefile is implemented)
        _money = 500;

        _moneyUI.text = "$" + _money;
    }

    /// <summary>
    /// Message that enable and disable Cheats
    /// </summary>
    private void SetCheatMode()
    {
        _cheatMode = !_cheatMode;
    }
}
