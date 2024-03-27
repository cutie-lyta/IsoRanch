using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private int _limit;

    [SerializeField]
    private TMP_Text _moneyUI;

    private int _money;

    public bool AddMoney(int amount)
    {
        if (_money < _limit)
        {
            _money += amount;
            _moneyUI.text = "$" + _money;
            return true;
        }

        return false;
    }

    public bool TakeMoney(int amount)
    {
        if (_money - amount > 0)
        {
            _money -= amount;
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
}
