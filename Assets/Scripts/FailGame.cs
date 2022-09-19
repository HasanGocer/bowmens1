using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            GameStart.Instance.inFail = true;
            Buttons.Instance.failGame.SetActive(true);
        }
    }
}
