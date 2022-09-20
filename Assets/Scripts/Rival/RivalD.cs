using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalD : MonoSingleton<RivalD>
{

    public RivalData rivalData = null;

    [System.Serializable]
    public class Field
    {
        public float archerArrowSpeed, archerShot, characterSpeed, Tower;
    }
    public Field field;

    public Field factor;
    public Field constant;
    public Field maxFactor;
    public Field max;
    public Field fieldPrice;
    public Field fieldPriceFactor;

    private void Start()
    {
        field.archerArrowSpeed = rivalData.archerArrowSpeedStandart - (factor.archerArrowSpeed * constant.archerArrowSpeed);
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
