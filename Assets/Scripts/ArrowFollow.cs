using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowFollow : MonoBehaviour
{
    public bool followBool;
    [SerializeField] private float _arrowCountdown;
    private float _arrowTime;
    [SerializeField] private int _OPArrowCount;
    private float _arrowSpeed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public IEnumerator ArrowRivalIntegratedV1(GameObject arrow, GameObject rival)
    {
        Vector3 pos = arrow.transform.position;

        while (!followBool)
        {
            //timer += Time.deltaTime * _arrowSpeed;
            arrow.transform.position = pos;
            arrow.transform.LookAt(rival.transform.position);

            //hýz kodu
            rb.velocity = transform.forward * Time.deltaTime * _arrowSpeed;

            yield return new WaitForSeconds(_arrowCountdown);
            pos = arrow.transform.position;
        }

        //ölme yeri
        if (followBool)
        {
            ObjectPool.Instance.AddObject(_OPArrowCount, this.gameObject);
            //partical 
        }
    }
    public IEnumerator ArrowRivalIntegratedV2(GameObject rival)
    {
        _arrowTime = RivalD.Instance.field.archerArrowSpeed;
        this.transform.DOMove(rival.transform.position, _arrowTime);
        yield return new WaitForSeconds(_arrowTime);
        ObjectPool.Instance.AddObject(_OPArrowCount, this.gameObject);
    }
}
