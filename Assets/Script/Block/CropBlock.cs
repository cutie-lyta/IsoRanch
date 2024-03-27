using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBlock : Block
{
    [SerializeField]
    private GameObject _finalPrefab;

    [SerializeField]
    private PlantBlockData _blockData;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        yield return new WaitForSeconds(_blockData.HarvestTime);
        var finishedPlant = Instantiate(_finalPrefab, this.transform.position, this.transform.rotation);
        finishedPlant.GetComponent<PlantBlock>().SetBlockData(_blockData);
        finishedPlant.transform.SetParent(this.transform.parent);
        Destroy(this.gameObject);
    }
}
