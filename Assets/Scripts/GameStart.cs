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

        if (PlayerPrefs.HasKey("archerArrowSpeedFactor"))
        {
            RivalD.Instance.factor.archerArrowSpeed = PlayerPrefs.GetInt("archerArrowSpeedFactor");
        }
        else
        {
            PlayerPrefs.SetInt("archerArrowSpeedFactor", 1);
        }

        if (PlayerPrefs.HasKey("archerArrowSpeedPrice"))
        {
            RivalD.Instance.fieldPrice.archerArrowSpeed = PlayerPrefs.GetInt("archerArrowSpeedPrice");
        }
        else
        {
            PlayerPrefs.SetInt("archerArrowSpeedPrice", 1);
        }

        if (PlayerPrefs.HasKey("archerShotFactor"))
        {
            RivalD.Instance.factor.archerShot = PlayerPrefs.GetInt("archerShotFactor");
        }
        else
        {
            PlayerPrefs.SetInt("archerShotFactor", 1);
        }

        if (PlayerPrefs.HasKey("archerShotPrice"))
        {
            RivalD.Instance.fieldPrice.archerShot = PlayerPrefs.GetInt("archerShotPrice");
        }
        else
        {
            PlayerPrefs.SetInt("archerShotPrice", 1);
        }

        if (PlayerPrefs.HasKey("characterSpeedFactor"))
        {
            RivalD.Instance.factor.characterSpeed = PlayerPrefs.GetInt("characterSpeedFactor");
        }
        else
        {
            PlayerPrefs.SetInt("characterSpeedFactor", 1);
        }

        if (PlayerPrefs.HasKey("characterSpeedPrice"))
        {
            RivalD.Instance.fieldPrice.characterSpeed = PlayerPrefs.GetInt("characterSpeedPrice");
        }
        else
        {
            PlayerPrefs.SetInt("characterSpeedPrice", 1);
        }

        if (PlayerPrefs.HasKey("towerFactor"))
        {
            RivalD.Instance.field.Tower = PlayerPrefs.GetInt("towerFactor");
        }
        else
        {
            PlayerPrefs.SetInt("towerFactor", 1);
        }

        if (PlayerPrefs.HasKey("towerPrice"))
        {
            RivalD.Instance.fieldPrice.Tower = PlayerPrefs.GetInt("towerPrice");
        }
        else
        {
            PlayerPrefs.SetInt("towerPrice", 1);
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
        PlayerPrefs.SetInt("archerArrowSpeedFactor", (int)RivalD.Instance.factor.archerArrowSpeed);
    }

    public void SetArcherArrowSpeedPrice()
    {
        PlayerPrefs.SetInt("archerArrowSpeedPrice", (int)RivalD.Instance.fieldPrice.archerArrowSpeed);
    }

    public void SetArcherShotFactor()
    {
        PlayerPrefs.SetInt("archerShotFactor", (int)RivalD.Instance.factor.archerShot);
    }

    public void SetArcherShotPrice()
    {
        PlayerPrefs.SetInt("archerShotPrice", (int)RivalD.Instance.fieldPrice.archerShot);
    }

    public void SetCharacterSpeedFactor()
    {
        PlayerPrefs.SetInt("characterSpeedFactor", (int)RivalD.Instance.factor.characterSpeed);
    }

    public void SetCharacterSpeedPrice()
    {
        PlayerPrefs.SetInt("characterSpeedPrice", (int)RivalD.Instance.fieldPrice.characterSpeed);
    }

    public void SetTowerFactor()
    {
        PlayerPrefs.SetInt("towerFactor", (int)RivalD.Instance.field.Tower);
    }

    public void SetTowerPrice()
    {
        PlayerPrefs.SetInt("towerPrice", (int)RivalD.Instance.fieldPrice.Tower);
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
