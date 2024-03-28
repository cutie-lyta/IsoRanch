using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private int _limit;

    [SerializeField]
    private TMP_Text _moneyUI;

    private int _money;

    [SerializeField]
    private bool _cheatMode;

    public void AddMoney(int amount)
    {
        if (_money < _limit)
        {
            _money += amount;
            _moneyUI.text = "$" + _money;
        }
    }

    public bool TakeMoney(int amount)
    {
        if ((_cheatMode ? 0 : (_money - amount)) >= 0)
        {
            _money -= _cheatMode ? 0 : amount;
            _moneyUI.text = "$" + _money;
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

    private void SetCheatMode()
    {
        _cheatMode = !_cheatMode;
    }
}
