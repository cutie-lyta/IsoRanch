using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant1_Block", menuName = "IsoRanch/PlantBlock")]
public class PlantBlockData : ScriptableObject
{
    [field: SerializeField]
    public DamageType DamageType { get; private set; }

    [field: SerializeField]
    public float Damage { get; private set; }

    [field: SerializeField]
    public PlantData Plant { get; private set; }

    [field: SerializeField]
    public float HarvestTime { get; private set; }

    [field: SerializeField]
    public int HarvestQuantity { get; private set; }
}

