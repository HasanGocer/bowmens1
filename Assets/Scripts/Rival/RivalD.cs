using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalD : MonoSingleton<RivalD>
{

    public RivalData rivalData = null;

    [System.Serializable]
    public class Field
    {
        public float archerArrowSpeed, archerShot, characterSpeed;
    }
    public Field field;

    [System.Serializable]
    public class Factor
    {
        public int archerArrowSpeed, archerShot, characterSpeed;
    }
    public Factor factor;

    [System.Serializable]
    public class Constant
    {
        public float arcerArrowSpeed, archerShot, characterSpeed;
    }
    public Constant constant;

    [System.Serializable]
    public class MaxFactor
    {
        public int archerArrowSpeed, archerShot, characterSpeed;
    }
    public MaxFactor maxFactor;

    [System.Serializable]
    public class Max
    {
        public float archerArrowSpeed, archerShot, characterSpeed;
    }
    public Max max;

    private void Start()
    {
        field.archerArrowSpeed = rivalData.archerArrowSpeedStandart - (factor.archerArrowSpeed * constant.arcerArrowSpeed);
        field.archerShot = rivalData.archerShotStandart + (factor.archerShot * constant.archerShot);
        field.characterSpeed = rivalData.characterSpeedStandart + (factor.characterSpeed * constant.characterSpeed);

        if (field.archerArrowSpeed < max.archerArrowSpeed)
        {
            field.archerArrowSpeed = max.archerArrowSpeed;
        }

        if (field.archerShot < max.archerShot)
        {
            field.archerShot = max.archerShot;
        }

        if (field.characterSpeed < max.characterSpeed)
        {
            field.characterSpeed = max.characterSpeed;
        }
    }
}
