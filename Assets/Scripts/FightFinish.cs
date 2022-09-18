using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FightFinish : MonoSingleton<FightFinish>
{
    [SerializeField] private int AddObject;

    public void Finish()
    {
        ObjectPool.Instance.AddObject(AddObject, this.gameObject);
    }
}
