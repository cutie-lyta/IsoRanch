using UnityEngine;

/// <summary>
/// Define the base behaviour of an animal, the "eat" action and the initialization.
/// </summary>
public abstract class AnimalBehaviour : Selectable
{
    /// <summary>
    /// The animal data stored.
    /// </summary>
    [SerializeField]
    private AnimalData _data;

    /// <summary>
    /// Make the animal eat when the Player take a plant of the correct foodtype at them.
    /// </summary>
    /// <param name="ctx"> The context of the action, including the held item. </param>
    public override void Action(ActionContext ctx)
    {
        var plant = ctx.HeldInHand as PlantData;
        if (plant)
        {
            if (plant.FoodType == _data.FoodType)
            {
                int multiplicative = 1;
                if (_data.FavoriteFood != null && plant == _data.FavoriteFood)
                {
                    multiplicative = 2;
                }

                GetComponent<SoundModule>().Play("eat");
                PlayerMain.Instance.Inventory.RemoveItem(ctx.HeldInHand);
                PlayerMain.Instance.Inventory.AddItem(_data.Drop, _data.DropAmount * multiplicative);
            }
        }
    }

    /// <summary>
    /// Initialize the animal on load.
    /// </summary>
    protected virtual void Awake()
    {
        Name = _data.Name;
        Description = _data.Description;

        var rnd = Random.Range(0, 128);
        print(rnd);
        if (rnd == 69)
        {
            print("SHINYYYYYYYYYYYYYYYYYYYYYYYYYYY!");
            Name += " Chromatique";
            foreach (var animalRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                animalRenderer.material = _data.ShinyMaterial;
            }
        }
    }
}
