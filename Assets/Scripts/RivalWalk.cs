using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RivalWalk : MonoSingleton<RivalWalk>
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnMainTime;
    [SerializeField] private float _rivalWalkTime;
    [SerializeField] private float distanceVertical, distanceHorizontal;
    [SerializeField] private int _rivalOPCount, _ParentOPCount;
    [SerializeField] private int _rivalPart = 1;
    [SerializeField] private int HardCodeAhmetAbe = 5;
    public GameObject rivalFreeParent;

    [SerializeField] private GameObject[] PathGO;
    public Vector3[] PathV3;

    private void Start()
    {
        //vectör 3 elden girilmediði için sayýsý atanýp deðerler yerleþtiriliyor ve yürüme komutu baþlýyor
        PathV3 = new Vector3[PathGO.Length];
        for (int i = 0; i < PathGO.Length; i++)
        {
            PathV3[i] = PathGO[i].transform.position;
        }
        StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        while (true)
        {
            if (GameStart.Instance.gameStart && !GameStart.Instance.inFight)
            {
                TeleportRival();
                yield return new WaitForSeconds(_spawnTime);
            }
            yield return null;
        }
    }

    private void TeleportRival()
    {
        GameStart.Instance.inFight = true;
        GameObject rivalParent = ObjectPool.Instance.GetPooledObject(_ParentOPCount);
        rivalParent.transform.position = rivalFreeParent.transform.position;
        for (int i1 = 1; i1 <= _rivalPart; i1++)
        {
            for (int i2 = 0; i2 < i1; i2++)
            {
                if (i1 != 1)
                {
                    //objeyi ObjectingPool dan çekip yerine yerleþtirip path te yürütülüyor
                    GameObject obj = ObjectPool.Instance.GetPooledObject(_rivalOPCount);

                    obj.transform.position = new Vector3(PathGO[0].transform.position.x + (distanceHorizontal * (float)((i1 - 1) / 2)) - (i2 * distanceHorizontal), PathGO[0].transform.position.y, PathGO[0].transform.position.z - (distanceVertical * i1));
                    obj.transform.SetParent(rivalParent.transform);

                    StartCoroutine(FinishWalk(obj));
                }
                else
                {
                    //objeyi ObjectingPool dan çekip yerine yerleþtirip path te yürütülüyor
                    GameObject obj = ObjectPool.Instance.GetPooledObject(_rivalOPCount);

                    obj.transform.position = PathGO[0].transform.position;
                    obj.transform.SetParent(rivalParent.transform);

                    if (_rivalPart < RivalD.Instance.factor.archerArrowSpeed + RivalD.Instance.factor.archerShot + RivalD.Instance.factor.characterSpeed)
                    {
                        _rivalPart = (int)(RivalD.Instance.factor.archerArrowSpeed + RivalD.Instance.factor.archerShot + RivalD.Instance.factor.characterSpeed);
                    }
                    if (_rivalPart >= GameStart.Instance.finishGame)
                    {
                        _rivalPart = GameStart.Instance.finishGame;
                        GameStart.Instance.inGameFinish = true;
                    }
                    StartCoroutine(FinishWalk(obj));
                }
            }
        }
        ArcherManager.Instance.totalRival = ((_rivalPart) * (_rivalPart + 1)) / 2;
        rivalParent.transform.DOPath(PathV3, _rivalWalkTime).SetEase(Ease.InSine);

    }

    IEnumerator FinishWalk(GameObject obj)
    {
        yield return new WaitForSeconds(_rivalWalkTime);
        ObjectPool.Instance.AddObject(_rivalOPCount, obj);
    }
}
