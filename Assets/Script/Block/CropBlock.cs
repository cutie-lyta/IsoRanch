using System.Collections;
using UnityEngine;

/// <summary>
/// A seed block that'll grow.
/// </summary>
public class CropBlock : Block
{
    [SerializeField]
    private GameObject _finalPrefab;

    [SerializeField]
    private PlantBlockData _blockData;

    private PlowedDirt _parent;

    private void Start()
    {
        _parent = this.transform.parent.GetComponent<PlowedDirt>();
        GetComponent<SoundModule>().Play("plant");

        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        yield return new WaitForSeconds(_blockData.HarvestTime);
        var finishedPlant = Instantiate(_finalPrefab, this.transform.position, this.transform.rotation);
        finishedPlant.transform.SetParent(this.transform.parent);
        _parent.Plant = finishedPlant;
        Destroy(this.gameObject);
    }
}
