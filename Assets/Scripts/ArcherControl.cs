using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherControl : MonoSingleton<ArcherControl>
{
    //KULLANILMIYOR

    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed, distance;
    public bool fire;
    Vector3 archerPosition;
    public void EnemyControl()
    {
        archerPosition = new Vector3(transform.position.x, enemy.transform.position.y, transform.position.z);
        distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (distance < 50 && distance > 5)
        {
            transform.LookAt(enemy.transform.position);
            Debug.Log(distance);
            fire = true;
        }
        if (distance > 50 && distance < 5)
        {
            fire = false;
        }
    }
}
