using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShot : MonoBehaviour
{
    [SerializeField] private int _OPArrowCount;
    [SerializeField] private float _countdawnArrow;

    IEnumerator Shot()
    {
        if (ArcherManager.Instance.focusRival.activeInHierarchy)
        {
            CharacterRotation.Instance.rival = ArcherManager.Instance.focusRival;

            GameObject objArrow = ObjectPlacement(_OPArrowCount);

            StartCoroutine(objArrow.GetComponent<ArrowFollow>().ArrowRivalIntegratedV2(ArcherManager.Instance.focusRival));
            yield return new WaitForSeconds(_countdawnArrow);

        }

        yield return null;
    }

    private GameObject ObjectPlacement(int _OPArrowCount)
    {
        GameObject objArrow = ObjectPool.Instance.GetPooledObjectAdd(_OPArrowCount);

        objArrow.transform.position = this.transform.position;
        objArrow.transform.rotation = this.transform.rotation;
        return objArrow;
    }
}
