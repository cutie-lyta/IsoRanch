using UnityEngine;

/// <summary>
/// The graphics for PlayerSelector.
/// </summary>
public class PlayerSelectorGraphics : MonoBehaviour
{
    private PlayerSelector _selector;

    private void Awake()
    {
        _selector = GetComponent<PlayerSelector>();
    }

    private void FixedUpdate()
    {
        UseOutline();
        StandingOutline();
    }

    /// <summary>
    /// Show to the player the object that the user can act on.
    /// </summary>
    private void UseOutline()
    {
        float rad = Math.QuantizeAngle(transform.rotation.eulerAngles.y, 4) * Mathf.PI / 180.0f;

        var transformVector = new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad)).normalized;

        Debug.DrawRay(transform.position + transformVector + Vector3.up, Vector3.down * 10, Color.red, 0.1f);
        if (Physics.Raycast(transform.position + transformVector + Vector3.up, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Selectionable") &&
                (_selector.CurrentUseBlock == null || _selector.CurrentUseBlock.gameObject != hit.transform.gameObject))
            {
                if (_selector.CurrentUseBlock)
                {
                    foreach (var rnd in _selector.CurrentUseBlock.GetComponentsInChildren<Renderer>())
                    {
                        rnd.materials[2].SetFloat("_WireframeWidth", -1f);
                    }
                }

                if (hit.transform.gameObject)
                {
                    bool isOverridden = false;
                    isOverridden = _selector.IsCurrentBlockInteractable(hit.transform.gameObject.GetComponent<Selectable>());

                    foreach (var rnd in hit.transform.GetComponentsInChildren<Renderer>())
                    {
                        var material = rnd.materials[2];
                        material.SetFloat("_WireframeWidth", 0.05f);
                        material.SetColor("_WireframeFrontColour", isOverridden ? Color.green : Color.red);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Show to the player the object that the user stands on.
    /// </summary>
    private void StandingOutline()
    {
        Debug.DrawRay(transform.position, Vector3.down * 10, Color.yellow, 0.1f);
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Selectionable") &&
                (_selector.CurrentStandingBlock == null || _selector.CurrentStandingBlock.gameObject != hit.transform.gameObject))
            {
                ActionContext context;
                context.HeldInHand = PlayerMain.Instance.Inventory.GetHeldItem();

                if (_selector.CurrentStandingBlock)
                {
                    foreach (var rnd in _selector.CurrentStandingBlock.GetComponentsInChildren<Renderer>())
                    {
                        rnd.materials[2].SetFloat("_WireframeWidth", -1f);
                    }
                }

                if (hit.transform.gameObject)
                {
                    foreach (var rnd in hit.transform.GetComponentsInChildren<Renderer>())
                    {
                        var material = rnd.materials[2];
                        material.SetFloat("_WireframeWidth", 0.05f);
                        material.SetColor("_WireframeFrontColour", Color.yellow);
                    }

                    hit.transform.gameObject.SendMessage("OnEnter", context);
                }
            }
        }
    }
}
