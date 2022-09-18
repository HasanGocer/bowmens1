using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalFocus : MonoBehaviour
{
    public List<GameObject> ControlObject = new List<GameObject>();
    private bool controlBool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            //önceden bu kayýt edilmiþ mi kontrol ediyor
            CheckRival(other.gameObject);

            //kaydedilmemiþse  hem buraya hem ArcherManager a kaydediyor
            if (controlBool == false)
            {
                AddRival(other.gameObject);
            }
        }
    }

    private void CheckRival(GameObject other)
    {
        for (int i = 0; i < ControlObject.Count; i++)
        {
            if (ControlObject[i] == other)
            {
                controlBool = true;
            }
        }
    }

    private void AddRival(GameObject other)
    {
        ArcherManager.Instance.Rival.Push(other);
        ControlObject.Add(other);
    }
}
