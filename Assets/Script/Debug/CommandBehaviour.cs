using UnityEngine;

/// <summary>
/// Some cheating tool made for testing.
/// </summary>
public class CommandBehaviour : MonoBehaviour
{
    private void Update()
    {
        // Control + D -> Take Damage
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            PlayerMain.Instance.Health.TakeDamage(1);
        }

        // Control + M -> Set money cheat mode : You can gain money but not lose money.
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKey(KeyCode.LeftControl))
        {
            PlayerMain.Instance.Money.SendMessage("SetCheatMode");
        }
    }
}
