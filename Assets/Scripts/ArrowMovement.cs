using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoSingleton<ArrowMovement>
{
    //KULLANILMIYOR

    public void MoveArrow(GameObject arrow, GameObject rival, float arrowSpeed, int opCount)
    {
        while (true)
        {
            Vector3.Lerp(transform.position, rival.transform.position, Time.deltaTime * arrowSpeed);
            if (arrow.transform.position == rival.transform.position)
            {
                ObjectPool.Instance.AddObject(opCount, arrow);
                break;
            }
        }
        //yield return null;
    }
}
