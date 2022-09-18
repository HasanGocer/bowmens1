using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalD : MonoSingleton<RivalD>
{
    public RivalData rivalData = null;

    public float archerArrowSpeed, archerShot, characterSpeed;
    [SerializeField] public float archerArrowSpeedFactor, archerShotFactor, characterSpeedFactor;
    [SerializeField] private float arcerArrowSpeedConstant, archerShotConstant, characterSpeedConstant;
    [SerializeField] private float arcerArrowSpeedMax = 0.1f;

    private void Start()
    {
        archerArrowSpeed = rivalData.archerArrowSpeedStandart - (archerArrowSpeedFactor * arcerArrowSpeedConstant);
        archerShot = rivalData.archerShotStandart + (archerShotFactor * archerShotConstant);
        characterSpeed = rivalData.characterSpeedStandart + (characterSpeedFactor * characterSpeedConstant);
        if (archerArrowSpeed < arcerArrowSpeedMax)
        {
            archerArrowSpeed = arcerArrowSpeedMax;
        }
    }
}
