using System.Collections;
using UnityEngine;

/// <summary>
/// A egg block that'll hatch.
/// </summary>
public class EggBlock : Block
{
    /// <summary>
    /// A cast of this block's data as a Egg block data being stored.
    /// </summary>
    private EggBlockData _blockData;

    protected override void Awake()
    {
        _blockData = Data as EggBlockData;
        StartCoroutine(Hatch());
    }

    /// <summary>
    /// Coroutine used to make the egg hatch
    /// The entity is placed slightly (and randomly) offset around the egg
    /// And rotated randomly.
    /// </summary>
    private IEnumerator Hatch()
    {
        yield return new WaitForSeconds(_blockData.HatchTime);

        for (int i = 0; i < _blockData.HatchQuantity; i++)
        {
            var pos = this.transform.position;
            pos.x += Random.Range(-1.0f, 1.0f);
            pos.z += Random.Range(-1.0f, 1.0f);

            var rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Instantiate(_blockData.Animal, pos, rot);
        }

        Destroy(this.gameObject);
    }
}
