using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTouch : MonoBehaviour
{
    [SerializeField] private int _OPRivalCount, _OPParticalCount;
    [SerializeField] private float _particalTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            ObjectPool.Instance.AddObject(_OPRivalCount, this.gameObject);
            transform.SetParent(RivalWalk.Instance.rivalFreeParent.transform);
            Partical(other);
            FightFinish.Instance.Finish();

            //partical çýkar
            other.GetComponent<ArrowFollow>().followBool = true;
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
