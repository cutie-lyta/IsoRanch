using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Vector3 _spawnpoint;

    private void Awake()
    {
        _spawnpoint = this.transform.position;
    }

    public void Die()
    {
        foreach (var ItemData in PlayerMain.Instance.Inventory.GetItems())
        {
            
        }
    }
}
