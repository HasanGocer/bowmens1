using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTouch : MonoBehaviour
{
    [SerializeField] private int _OPRivalCount, _OPParticalCount, _OPArrowCount;
    [SerializeField] private float _particalTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow") && !GameStart.Instance.inFail)
        {
            ObjectPool.Instance.AddObject(_OPRivalCount, this.gameObject);
            ObjectPool.Instance.AddObject(_OPArrowCount, other.gameObject);
            other.GetComponent<ArrowFollow>().touchBool = true;
            transform.SetParent(RivalWalk.Instance.rivalFreeParent.transform);
            Partical(other);
            ArcherManager.Instance.DeadRival++;

            other.GetComponent<ArrowFollow>().followBool = true;

            if (GameStart.Instance.lastOne)
            {
                GameStart.Instance.inMarket = true;
                Buttons.Instance.marketGame.SetActive(true);
                ArcherManager.Instance.DeadRival = 0;
            }
        }
    }

    IEnumerator Partical(Collider other)
    {
        GameObject objPartical = ObjectPool.Instance.GetPooledObject(_OPParticalCount);
        objPartical.transform.position = other.transform.position;
        yield return new WaitForSeconds(_particalTime);
        ObjectPool.Instance.AddObject(_OPParticalCount, objPartical);
    }
}
