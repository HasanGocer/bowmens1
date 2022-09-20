using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoSingleton<GameStart>
{
    public bool gameStart;
    public bool inFight = false;
    public bool inFinish;
    public bool inGameFinish;
    public bool inFail;
    public bool lastOne;
    public bool inMarket;

    public int MarketSelectWindow;

    public int vibration, sound, level, money, finishGame;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
            Buttons.Instance.moneyText.text = money.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
            Buttons.Instance.moneyText.text = money.ToString();
        }

        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
            Buttons.Instance.levelText.text = level.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("level", 0);
            Buttons.Instance.levelText.text = level.ToString();
        }

        if (PlayerPrefs.HasKey("vibration"))
        {
            vibration = PlayerPrefs.GetInt("vibration");
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 1);
        }

        if (PlayerPrefs.HasKey("sound"))
        {
            sound = PlayerPrefs.GetInt("sound");
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
        }

        if (PlayerPrefs.HasKey("archerArrowSpeed"))
        {
            RivalD.Instance.factor.archerArrowSpeed = PlayerPrefs.GetInt("archerArrowSpeed");
        }
        else
        {
            PlayerPrefs.SetInt("archerArrowSpeed", 1);
        }

        if (PlayerPrefs.HasKey("archerShot"))
        {
            RivalD.Instance.factor.archerShot = PlayerPrefs.GetInt("archerShot");
        }
        else
        {
            PlayerPrefs.SetInt("archerShot", 1);
        }

        if (PlayerPrefs.HasKey("characterSpeed"))
        {
            RivalD.Instance.factor.characterSpeed = PlayerPrefs.GetInt("characterSpeed");
        }
        else
        {
            PlayerPrefs.SetInt("characterSpeed", 1);
        }

        if (PlayerPrefs.HasKey("Tower"))
        {
            RivalD.Instance.field.Tower = PlayerPrefs.GetInt("Tower");
        }
        else
        {
            PlayerPrefs.SetInt("Tower", 1);
        }
    }

    public void SetSound()
    {
        PlayerPrefs.SetInt("sound", sound);
    }

    public void SetVibration()
    {
        PlayerPrefs.SetInt("vibration", vibration);
    }

    public void SetArcherArrowSpeedFactor()
    {
        PlayerPrefs.SetInt("archerArrowSpeed", (int)RivalD.Instance.factor.archerArrowSpeed);
    }

    public void SetArcherShotFactor()
    {
        PlayerPrefs.SetInt("archerShot", (int)RivalD.Instance.factor.archerShot);
    }

    public void SetCharacterSpeedFactor()
    {
        PlayerPrefs.SetInt("characterSpeed", (int)RivalD.Instance.factor.characterSpeed);
    }

    private void SetTowerFactor()
    {
        PlayerPrefs.SetInt("tower", (int)RivalD.Instance.field.Tower);
    }

    public void MoneySet()
    {
        PlayerPrefs.SetInt("money", money);
        Buttons.Instance.moneyText.text = GameStart.Instance.money.ToString();
    }

    public void LevelSet()
    {
        PlayerPrefs.SetInt("Level", level);
        Buttons.Instance.levelText.text = GameStart.Instance.level.ToString();
    }
}
