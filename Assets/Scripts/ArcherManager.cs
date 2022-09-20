using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherManager : MonoSingleton<ArcherManager>
{
    [System.Serializable]
    public class TowerClass
    {
        public GameObject TowerTemplate;
        public List<GameObject> Archer = new List<GameObject>();
        public List<GameObject> ArrowPos = new List<GameObject>();
        public List<GameObject> Tower = new List<GameObject>();
    }
    public TowerClass[] Towers;

    public List<int> ArcherType = new List<int>();
    public List<bool> ArcherBool = new List<bool>();
    public Stack<GameObject> Rival = new Stack<GameObject>();
    [SerializeField] private int _towerCount;
    [SerializeField] private int _OPArrowCount, _OPRivalCount, _OPParticalCount;
    public GameObject focusRival;
    public int totalRival, DeadRival;
    private float _rotationCountdown = 0.1f;

    private void Start()
    {
        TowerSelected();

        StartCoroutine(ArrowShot());
    }

    private void TowerSelected()
    {
        //Tower bilgi atamasý
        for (int i1 = 0; i1 < _towerCount; i1++)
        {
            for (int i2 = 0; i2 < 3; i2++)
            {
                Towers[i1].Tower.Add(Towers[i1].TowerTemplate.transform.GetChild((i2 * 2)).gameObject);
                Towers[i1].Archer.Add(Towers[i1].TowerTemplate.transform.GetChild(1 + (i2 * 2)).gameObject);
                Towers[i1].ArrowPos.Add(Towers[i1].TowerTemplate.transform.GetChild(1 + (i2 * 2)).transform.GetChild(0).gameObject);

            }

            if (ArcherBool[i1])
            {
                Towers[i1].Tower[ArcherType[i1]].SetActive(true);
                Towers[i1].Archer[ArcherType[i1]].SetActive(true);
            }

        }
    }

    IEnumerator ArrowShot()
    {
        while (true)
        {
            //rival var mý yok mu kontrol ediyor
            if (Rival.Count > 0)
            {
                //Rival hareketi bittiðinde setactive kapandýðýndan öncesindeki rival a odaklanýyor
                if (!focusRival.activeInHierarchy)
                {
                    focusRival = Rival.Pop();
                    CharacterRotation.Instance.rival = focusRival;
                    for (int i = 0; i < _towerCount; i++)
                    {
                        Towers[i].Archer[ArcherType[i]].GetComponent<ArcherRotate>().rival = focusRival;
                    }
                    yield return new WaitForSeconds(_rotationCountdown);

                    if (DeadRival == totalRival - 1)
                    {
                        GameStart.Instance.lastOne = true;
                    }
                }
                if (!GameStart.Instance.inFail)
                {
                    //kulelerin hepsinni ateþ etmesi saðlanýyor
                    for (int i = 0; i < _towerCount; i++)
                    {
                        //objecting pooldan arrow çekiyoruz. rotasyon ve position atamasý yapýlýr ve Arrow takip edilir
                        GameObject objArrow = ObjectPlacement(_OPArrowCount, i);

                        //StartCoroutine(objArrow.GetComponent<ArrowFollow>().ArrowRivalIntegratedV1( focusRival));
                        StartCoroutine(objArrow.GetComponent<ArrowFollow>().ArrowRivalIntegratedV2(focusRival));
                        yield return new WaitForSeconds(_rotationCountdown);
                    }
                    yield return new WaitForSeconds(1 / RivalD.Instance.field.archerShot);
                }
            }
            yield return null;
        }
    }

    private GameObject ObjectPlacement(int _OPArrowCount, int i)
    {
        GameObject objArrow = ObjectPool.Instance.GetPooledObjectAdd(_OPArrowCount);

        objArrow.transform.position = Towers[i].ArrowPos[ArcherType[i]].transform.position;
        objArrow.transform.rotation = Towers[i].ArrowPos[ArcherType[i]].transform.rotation;
        return objArrow;
    }
}
