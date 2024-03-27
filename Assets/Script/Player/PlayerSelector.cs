using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject CurrentStandingBlock { get; private set; }

    public GameObject CurrentUseBlock { get; private set; }

    private void FixedUpdate()
    {
        UseOutline();
        StandingOutline();
    }

    private float QuantizeAngle(float angle, int quantization)
    {
        var array = new List<float>();

        for (int i = 0; i < 360; i += 360 / quantization)
        {
            array.Add(i);
        }

        float rotation = angle;
        return array.OrderBy(x => Math.Abs((long)x - rotation)).First();
    }

    private void UseOutline()
    {
        float rad = QuantizeAngle(transform.rotation.eulerAngles.y, 4) * Mathf.PI / 180;

        var transformVector = new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad)).normalized;

        if (Physics.Raycast(transform.position + transformVector + Vector3.up, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Standable") && CurrentUseBlock != hit.transform.gameObject)
            {
                if (CurrentUseBlock)
                {
                    CurrentUseBlock.gameObject.GetComponent<Renderer>().materials[2].SetFloat("_WireframeWidth", -1f);
                }

                if (hit.transform.gameObject)
                {
                    CurrentUseBlock = hit.transform.gameObject;
                    var material = hit.transform.GetComponent<Renderer>().materials[2];
                    material.SetFloat("_WireframeWidth", 0.05f);

                    // Get with Reflection if the method action is overridden -> A.K.A. if you technically can interact with that tile
                    var block = hit.transform.GetComponent<Block>();
                    var meth = block.GetType().GetMethod(
                        "Action", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);

                    bool isOverridden = false;
                    if (meth is not null)
                    {
                        isOverridden = meth?.DeclaringType != typeof(Block);
                    }

                    material.SetColor("_WireframeFrontColour", isOverridden ? Color.green : Color.red);
                }
            }
        }
    }

    private void StandingOutline()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Standable") && CurrentStandingBlock != hit.transform.gameObject)
            {
                ActionContext context;
                context.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

                if (CurrentStandingBlock)
                {
                    CurrentStandingBlock.gameObject.GetComponent<Renderer>().materials[2].SetFloat("_WireframeWidth", -1f);
                    CurrentStandingBlock.SendMessage("OnExit", context);
                }

                if (hit.transform.gameObject)
                {
                    CurrentStandingBlock = hit.transform.gameObject;
                    var material = hit.transform.GetComponent<Renderer>().materials[2];
                    CurrentStandingBlock.SendMessage("OnEnter", context);

                    material.SetFloat("_WireframeWidth", 0.05f);
                    material.SetColor("_WireframeFrontColour", Color.yellow);
                }
            }
        }
    }
}
