using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShot : MonoBehaviour
{
    //karakterin ok atmasý için kullanýlan script

    [SerializeField] private int _OPArrowCount;
    [SerializeField] private float _countdawnArrow;

    private void Start()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        while (true)
        {
            if (ArcherManager.Instance.focusRival.activeInHierarchy)
            {
                GameObject objArrow = ObjectPlacement(_OPArrowCount);

                StartCoroutine(objArrow.GetComponent<ArrowFollow>().ArrowRivalIntegratedV2(ArcherManager.Instance.focusRival));
                yield return new WaitForSeconds(_countdawnArrow);
            }
            yield return null;
        }
    }

    private GameObject ObjectPlacement(int _OPArrowCount)
    {
        GameObject objArrow = ObjectPool.Instance.GetPooledObjectAdd(_OPArrowCount);

        objArrow.transform.position = this.transform.position;
        objArrow.transform.rotation = this.transform.rotation;
        return objArrow;
    }
}
