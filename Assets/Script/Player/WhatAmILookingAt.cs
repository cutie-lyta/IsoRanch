using TMPro;
using UnityEngine;

/// <summary>
/// The What Am I Looking At component
/// A component that show the name (and description) of what the Player is looking at.
/// Inspired by the Minecraft mod of the same name, and Slime Rancher's similar functionality
/// </summary>
public class WhatAmILookingAt : MonoBehaviour
{
    /// <summary>
    /// The name's text box
    /// </summary>
    [SerializeField]
    private TMP_Text _name;

    /// <summary>
    /// The description's text box.
    /// </summary>
    [SerializeField]
    private TMP_Text _description;

    private void FixedUpdate()
    {
        if (PlayerMain.Instance.Selector.CurrentUseBlock is not null)
        {
            _name.text = PlayerMain.Instance.Selector.CurrentUseBlock.Name;
            _description.text = PlayerMain.Instance.Selector.CurrentUseBlock.Description;
        }
    }
}
