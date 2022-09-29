using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ana karakterin hareket scripti

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    Touch touch;

    private Vector3 touchDown, touchUp;

    private bool dragStarted, isMoving;

    void Update()
    {
        if (GameStart.Instance.gameStart)
        {
            Movement();
        }
    }

    void Movement()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                isMoving = true;
                touchDown = touch.position;
                touchUp = touch.position;
            }

        }
        if (dragStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                touchUp = touch.position;
                AnimationConrol.Instance.CallRunningAnimtator();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                touchDown = touch.position;
                isMoving = false;
                dragStarted = false;
                AnimationConrol.Instance.CallIdleAnimator();
            }

            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = (touchDown - touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
}
