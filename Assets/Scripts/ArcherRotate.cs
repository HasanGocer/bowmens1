using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherRotate : MonoBehaviour
{
    //kulelerdeki ok�ular�n focuslanm�� rivale d�nmesini sa�layan komuttur (a�a�� d�nmesi engellenir)

    public GameObject rival;
    private float rotx, rotz;

    private void Update()
    {
        if (rival != null)
        {
            if (rival.activeInHierarchy)
            {
                rotx = this.transform.rotation.x;
                rotz = this.transform.rotation.z;
                this.transform.LookAt(rival.transform.position);
                this.transform.rotation = Quaternion.Euler(new Vector3(rotx, this.transform.rotation.y, rotz));
            }
        }
    }
}
