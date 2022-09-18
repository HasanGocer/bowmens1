using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float takenSpeed;
    private void Start()
    {
        if (!target)
        {
            target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(transform.position, target.position + offset, takenSpeed * Time.deltaTime);
    }
}
