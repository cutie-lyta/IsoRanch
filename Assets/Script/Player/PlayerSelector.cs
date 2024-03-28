using System;
using System.Reflection;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public Selectable CurrentStandingBlock { get; private set; }

    public Selectable CurrentUseBlock { get; private set; }

    public bool IsCurrentBlockInteractable(Selectable block)
    {
        // Get with Reflection if the method action is overridden -> A.K.A. if you technically can interact with that tile
        var meth = block.GetType().GetMethod(
            "Action", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(ActionContext) }, null);

        if (meth is not null)
        {
            return meth.DeclaringType != typeof(Selectable);
        }

        return false;
    }

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
