using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoSingleton<GameStart>
{
    //GAME MANAGER

    public bool gameStart;
    public bool inFight = false;
    public bool inFinish;
    public bool inGameFinish;
    public bool inFail;
    public bool lastOne;
    public bool inMarket;

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

        if (PlayerPrefs.HasKey("bow1"))
        {

            Buttons.Instance.bowSelectCount[0] = PlayerPrefs.GetInt("bow1");
        }
        else
        {
            PlayerPrefs.SetInt("bow1", 2);
        }

        if (PlayerPrefs.HasKey("bow2"))
        {

            Buttons.Instance.bowSelectCount[1] = PlayerPrefs.GetInt("bow2");
        }
        else
        {
            PlayerPrefs.SetInt("bow2", 2);
        }

        if (PlayerPrefs.HasKey("bow3"))
        {

            Buttons.Instance.bowSelectCount[2] = PlayerPrefs.GetInt("bow3");
        }
        else
        {
            PlayerPrefs.SetInt("bow3", 2);
        }

        if (PlayerPrefs.HasKey("bow4"))
        {

            Buttons.Instance.bowSelectCount[3] = PlayerPrefs.GetInt("bow4");
        }
        else
        {
            PlayerPrefs.SetInt("bow4", 2);
        }

        if (PlayerPrefs.HasKey("bow5"))
        {

            Buttons.Instance.bowSelectCount[4] = PlayerPrefs.GetInt("bow5");
        }
        else
        {
            PlayerPrefs.SetInt("bow5", 2);
        }

        if (PlayerPrefs.HasKey("bow6"))
        {

            Buttons.Instance.bowSelectCount[5] = PlayerPrefs.GetInt("bow6");
        }
        else
        {
            PlayerPrefs.SetInt("bow6", 2);
        }

        if (PlayerPrefs.HasKey("bow7"))
        {

            Buttons.Instance.bowSelectCount[6] = PlayerPrefs.GetInt("bow7");
        }
        else
        {
            PlayerPrefs.SetInt("bow7", 2);
        }

        if (PlayerPrefs.HasKey("bow8"))
        {

            Buttons.Instance.bowSelectCount[7] = PlayerPrefs.GetInt("bow8");
        }
        else
        {
            PlayerPrefs.SetInt("bow8", 1);
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

    public void BowSet(int count)
    {
        if (count == 1)
        {
            PlayerPrefs.SetInt("bow1", Buttons.Instance.bowSelectCount[0]);
        }
        else if (count == 2)
        {
            PlayerPrefs.SetInt("bow2", Buttons.Instance.bowSelectCount[1]);
        }
        else if (count == 3)
        {
            PlayerPrefs.SetInt("bow3", Buttons.Instance.bowSelectCount[2]);
        }
        else if (count == 4)
        {
            PlayerPrefs.SetInt("bow4", Buttons.Instance.bowSelectCount[3]);
        }
        else if (count == 5)
        {
            PlayerPrefs.SetInt("bow5", Buttons.Instance.bowSelectCount[4]);
        }
        else if (count == 6)
        {
            PlayerPrefs.SetInt("bow6", Buttons.Instance.bowSelectCount[5]);
        }
        else if (count == 7)
        {
            PlayerPrefs.SetInt("bow7", Buttons.Instance.bowSelectCount[6]);
        }
        else if (count == 8)
        {
            PlayerPrefs.SetInt("bow8", Buttons.Instance.bowSelectCount[7]);
        }

    }
}
