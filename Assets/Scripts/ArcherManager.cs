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
    [SerializeField] private GameObject _focusRival;
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
                if (!_focusRival.activeInHierarchy)
                {
                    _focusRival = Rival.Pop();
                    for (int i = 0; i < _towerCount; i++)
                    {
                        Towers[i].Archer[ArcherType[i]].GetComponent<ArcherRotate>().rival = _focusRival;
                    }
                    yield return new WaitForSeconds(_rotationCountdown);
                }

                //kulelerin hepsinni ateþ etmesi saðlanýyor
                for (int i = 0; i < _towerCount; i++)
                {
                    //objecting pooldan arrow çekiyoruz. rotasyon ve position atamasý yapýlýr ve Arrow takip edilir
                    GameObject objArrow = ObjectPlacement(_OPArrowCount, i);

                    //StartCoroutine(objArrow.GetComponent<ArrowFollow>().ArrowRivalIntegratedV1( _focusRival));
                    StartCoroutine(objArrow.GetComponent<ArrowFollow>().ArrowRivalIntegratedV2(_focusRival));
                    yield return new WaitForSeconds(_rotationCountdown);
                }
                yield return new WaitForSeconds(1 / RivalD.Instance.archerShot);
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
