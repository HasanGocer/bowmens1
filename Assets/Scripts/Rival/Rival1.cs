using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival1 : MonoBehaviour
{
    public RivalData1 rivalData1 = null;

    public float currentHealth;

    private void Start()
    {
        currentHealth = rivalData1._maxHealth;
    }
}
