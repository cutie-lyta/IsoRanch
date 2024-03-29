using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Component that keep track of the player health and draws it to the screen.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// The list of hearts in the UI.
    /// </summary>
    [SerializeField]
    private List<Image> _hearts;

    /// <summary>
    /// The health of the player, should always be between 0 and 20, in normal condition.
    /// </summary>
    private int _health = 20;

    /// <summary>
    /// A handle to the death component of the player.
    /// </summary>
    private PlayerDeath _death;

    /// <summary>
    /// Remove HP from the user
    /// </summary>
    /// <param name="damage"> the number of hit points to take. </param>
    public void TakeDamage(int damage)
    {
        _health -= damage;
        DrawHearts();

        if (_health <= 0)
        {
            _health = 0;
            StartCoroutine(_death.Die());
            PlayerMain.Instance.SoundModule.Play("death");
            return;
        }

        PlayerMain.Instance.SoundModule.Play("damage");
    }

    /// <summary>
    /// Heal the user with some HP
    /// </summary>
    /// <param name="heal"> the number of hit points to give back. </param>
    public void AddHealth(int heal)
    {
        _health += heal;
        if (_health > 20)
        {
            _health = 20;
        }

        DrawHearts();
    }

    private void Awake()
    {
        _death = GetComponent<PlayerDeath>();
        DrawHearts();
    }

    /// <summary>
    /// Draw the hearts on the screen to have a visual feedback for health.
    /// </summary>
    private void DrawHearts()
    {
        var active = Mathf.Floor((float)_health / 2);
        var halfBright = _health % 2 == 1;

        int i = 0;
        for (; i < active; i++)
        {
            print(i);
            _hearts[i].color = Color.red;
        }

        if (halfBright)
        {
            _hearts[i].color = new Color(.5f, .1f, 0);
            i++;
        }

        for (; i < 10; i++)
        {
            _hearts[i].color = Color.grey;
        }
    }
}
