using System.Collections;
using UnityEngine;

/// <summary>
/// Component that take care of the player's death and respawning behaviour.
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    /// <summary>
    /// Contain the player's spawnpoint. When dead, the player will be teleported here
    /// </summary>
    private Vector3 _spawnpoint;

    /// <summary>
    /// Die : Empty inventory, Take money and respawn.
    /// </summary>
    /// <returns> IEnumerator -> The coroutine wait and stuff. </returns>
    public IEnumerator Die()
    {
        // Show screen
        // Empty inventory.
        foreach (var itemData in PlayerMain.Instance.Inventory.GetItems())
        {
            int count = PlayerMain.Instance.Inventory.GetItemAmount(itemData);
            PlayerMain.Instance.Inventory.RemoveItem(itemData, count);
        }

        PlayerMain.Instance.Money.TakeMoney(20);

        yield return new WaitForSeconds(0.5f);

        PlayerMain.Instance.Health.AddHealth(20);
        this.transform.position = _spawnpoint;
    }

    /// <summary>
    /// Collide with death plane
    /// </summary>
    /// <param name="other"> if the tag of other is Respawn =>
    /// take an ABYSMAL amount of damage, effectively killing the player.
    /// </param>
    private void OnCollisionEnter(Collision other)
    {
        // Check death plain
        if (other.gameObject.CompareTag("Respawn"))
        {
            PlayerMain.Instance.Health.TakeDamage(99);
        }
    }

    private void Awake()
    {
        _spawnpoint = this.transform.position;
    }
}
