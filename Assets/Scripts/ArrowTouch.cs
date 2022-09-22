using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTouch : MonoBehaviour
{
    [SerializeField] private int _OPRivalCount, _OPParticalCount, _OPArrowCount;
    [SerializeField] private int minRandomMoney, maxRandomMoney;
    [SerializeField] private float _particalTime;
    [SerializeField] private bool inArrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow") && !GameStart.Instance.inFail && !inArrow)
        {
            ArcherManager.Instance.DeadRival++;
            inArrow = true;
            ObjectPool.Instance.AddObject(_OPRivalCount, this.gameObject);
            ObjectPool.Instance.AddObject(_OPArrowCount, other.gameObject);
            other.GetComponent<ArrowFollow>().touchBool = true;
            transform.SetParent(RivalWalk.Instance.rivalFreeParent.transform);
            GameStart.Instance.money += Random.Range(minRandomMoney, maxRandomMoney);
            GameStart.Instance.MoneySet();
            Partical(other);

            other.GetComponent<ArrowFollow>().followBool = true;

            if (GameStart.Instance.lastOne)
            {
                if (!GameStart.Instance.inGameFinish)
                {
                    GameStart.Instance.gameStart = false;
                    GameStart.Instance.lastOne = false;
                    Buttons.Instance.startGame.SetActive(true);
                    ArcherManager.Instance.DeadRival = 0;
                }
            }
        }
        else if (other.CompareTag("Player"))
        {
            Buttons.Instance.failGame.SetActive(true);
            GameStart.Instance.inFail = true;
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
