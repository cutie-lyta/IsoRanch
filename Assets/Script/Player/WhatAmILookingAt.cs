using TMPro;
using UnityEngine;

public class WhatAmILookingAt : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _name;

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
