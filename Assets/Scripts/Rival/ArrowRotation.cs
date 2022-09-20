using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    [SerializeField] private float time;
    public static ArrowRotation instance;
    private void Awake()
    {
        instance = this;
    }
    public void ArrowRot(GameObject rival)
    {
        Quaternion arrowRotation = Quaternion.Euler(rival.transform.position.x,transform.position.y,rival.transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, arrowRotation, time * Time.deltaTime);
        Debug.Log("ÇALIÞIYOR");
        transform.LookAt(rival.transform.position);
    }
}
