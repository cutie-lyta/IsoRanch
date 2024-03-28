using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Vector3 _spawnpoint;
    private PlayerHealth _health;

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

        _health.AddHealth(20);
        this.transform.position = _spawnpoint;

        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Check death plain
        if (other.gameObject.CompareTag("Respawn"))
        {
            _health.TakeDamage(99);
        }
    }

    private void Awake()
    {
        _spawnpoint = this.transform.position;
        _health = GetComponent<PlayerHealth>();
    }
}
