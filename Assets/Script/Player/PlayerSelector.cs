using System;
using System.Reflection;
using UnityEngine;

/// <summary>
/// This component calculate and keep track of the block that the player is standing on,
/// and the object that the player can use.
/// </summary>
public class PlayerSelector : MonoBehaviour
{
    public Selectable CurrentStandingBlock { get; private set; }

    public Selectable CurrentUseBlock { get; private set; }

    /// <summary>
    /// Calculate using reflection if the block is interactive (Have an Action behaviour overridden).
    /// </summary>
    /// <param name="block"> The Selectable you want to check </param>
    /// <returns> Return True if it is interactive. </returns>
    public bool IsCurrentBlockInteractable(Selectable block)
    {
        var meth = block.GetType().GetMethod(
            "Action", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(ActionContext) }, null);

        if (meth is not null)
        {
            return meth.DeclaringType != typeof(Selectable);
        }

        return false;
    }

    /// <summary>
    /// Calculate the object that the user can act on.
    /// </summary>
    private void UseOutline()
    {
        float rad = Math.QuantizeAngle(transform.rotation.eulerAngles.y, 4) * Mathf.PI / 180;

        var transformVector = new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad)).normalized;

        if (Physics.Raycast(transform.position + transformVector + Vector3.up, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Selectionable") &&
                (CurrentUseBlock == null || CurrentUseBlock.gameObject != hit.transform.gameObject))
            {
                if (hit.transform.gameObject)
                {
                    CurrentUseBlock = hit.transform.gameObject.GetComponent<Selectable>();
                }
            }
        }
    }

    /// <summary>
    /// Calculate the object that the user stands on.
    /// </summary>
    private void StandingOutline()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Selectionable") &&
                (CurrentStandingBlock == null || CurrentStandingBlock.gameObject != hit.transform.gameObject))
            {
                ActionContext context;
                context.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

                if (CurrentStandingBlock)
                {
                    CurrentStandingBlock.SendMessage("OnExit", context);
                }

                if (hit.transform.gameObject)
                {
                    CurrentStandingBlock = hit.transform.gameObject.GetComponent<Selectable>();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        UseOutline();
        StandingOutline();
    }
}
