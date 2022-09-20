using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoSingleton<Buttons>
{
    [SerializeField] private GameObject _GlobalGame;
    public Text moneyText;
    public Text levelText;

    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _startGame;

    [SerializeField] private Sprite _red, _green;
    [SerializeField] private Button _settingBackButton;

    [SerializeField] private Button _soundButton, _vibrationButton;

    [SerializeField] private Button _settingButton;
    [SerializeField] private GameObject _settingGame;

    [SerializeField] private Button _archerArrowSpeedButton, _archerShotButton, _characterSpeedButton, _towerButton;
    [SerializeField] private Text _archerArrowSpeedText, _archerShotText, _characterSpeedText, _towerText;
    [SerializeField] private Text _archerArrowSpeedPriceText, _archerShotPriceText, _characterSpeedPriceText, _towerPriceText;
    [SerializeField] private List<Button> _marketSelectedButton = new List<Button>();
    [SerializeField] private List<GameObject> _marketSelectedGame = new List<GameObject>();
    [SerializeField] private Button backToGame;
    public GameObject marketGame;

    [SerializeField] private Button _finishButton;
    public GameObject finishGame;

    [SerializeField] private Button _failResumeButton, _failRetryButton;
    public GameObject failGame;

    [SerializeField] private Button _rewardButton;
    public GameObject mainChestGame, chestChoseGame, openChestGame;
    [SerializeField] private Button _chest1Button, _chest2Button, _chest3Button;
    [SerializeField] private Image _chestImage1, _chestImage2;
    [SerializeField] private Text _chestMoney;
    [SerializeField] private Button _rewardLastButton;


    private void Start()
    {
        _startButton.onClick.AddListener(StartButton);
        _soundButton.onClick.AddListener(SoundButton);
        _vibrationButton.onClick.AddListener(VibrationButton);
        _archerArrowSpeedButton.onClick.AddListener(ArcherArrowSpeedFactorPlus);
        _archerShotButton.onClick.AddListener(ArcherShotFactorPlus);
        _characterSpeedButton.onClick.AddListener(CharacterSpeedFactorPlus);
        _towerButton.onClick.AddListener(TowerFactorPlus);
        backToGame.onClick.AddListener(BackToTheGame);
        _settingButton.onClick.AddListener(SettingButton);
        _settingBackButton.onClick.AddListener(SettingBackButton);
        _finishButton.onClick.AddListener(FinishButton);
        _failResumeButton.onClick.AddListener(FailResumeButton);
        _failRetryButton.onClick.AddListener(FailRetryButton);
        _rewardButton.onClick.AddListener(RewardOpen);
        _chest1Button.onClick.AddListener(OpenChest);
        _chest2Button.onClick.AddListener(OpenChest);
        _chest3Button.onClick.AddListener(OpenChest);
        _rewardLastButton.onClick.AddListener(RewardLastButton);


        if (GameStart.Instance.sound == 1)
        {
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            //SoundSystem.Instance.MainMusicPlay();
        }
        else
        {
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
        }

        if (GameStart.Instance.vibration == 1)
        {
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
        }
        else
        {
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
        }
    }

    private void TowerFactorPlus()
    {
        if (RivalD.Instance.fieldPrice.Tower <= GameStart.Instance.money)
        {
            GameStart.Instance.money -= (int)RivalD.Instance.fieldPrice.Tower;
            GameStart.Instance.MoneySet();
            RivalD.Instance.fieldPrice.Tower = (int)(RivalD.Instance.fieldPrice.Tower * RivalD.Instance.fieldPriceFactor.Tower);
            RivalD.Instance.factor.Tower++;
            RivalD.Instance.field.Tower++;
            ArcherManager.Instance.TowerAdd();
            _towerPriceText.text = "Price : " + RivalD.Instance.fieldPrice.Tower;
            GameStart.Instance.SetArcherArrowSpeedFactor();
            _towerText.text = RivalD.Instance.field.archerArrowSpeed.ToString();

        }
    }

    private void ArcherArrowSpeedFactorPlus()
    {
        if (RivalD.Instance.fieldPrice.archerArrowSpeed <= GameStart.Instance.money)
        {
            GameStart.Instance.money -= (int)RivalD.Instance.fieldPrice.archerArrowSpeed;
            GameStart.Instance.MoneySet();
            RivalD.Instance.fieldPrice.archerShot = (int)(RivalD.Instance.fieldPrice.archerArrowSpeed * RivalD.Instance.fieldPriceFactor.archerArrowSpeed);
            RivalD.Instance.factor.archerArrowSpeed++;
            _archerArrowSpeedPriceText.text = "Price : " + RivalD.Instance.fieldPrice.archerArrowSpeed;
            GameStart.Instance.SetArcherArrowSpeedFactor();
            _archerArrowSpeedText.text = RivalD.Instance.field.archerArrowSpeed.ToString();
        }
    }

    private void ArcherShotFactorPlus()
    {
        if (RivalD.Instance.fieldPrice.archerShot <= GameStart.Instance.money)
        {
            GameStart.Instance.money -= (int)RivalD.Instance.fieldPrice.archerShot;
            GameStart.Instance.MoneySet();
            RivalD.Instance.fieldPrice.archerShot = (int)(RivalD.Instance.fieldPrice.archerShot * RivalD.Instance.fieldPriceFactor.archerShot);
            RivalD.Instance.factor.archerShot++;
            _archerShotPriceText.text = "Price : " + RivalD.Instance.fieldPrice.archerShot;
            GameStart.Instance.SetArcherShotFactor();
            _archerShotText.text = RivalD.Instance.field.archerShot.ToString();
        }
    }

    private void CharacterSpeedFactorPlus()
    {
        if (RivalD.Instance.fieldPrice.characterSpeed <= GameStart.Instance.money)
        {
            GameStart.Instance.money -= (int)RivalD.Instance.fieldPrice.characterSpeed;
            GameStart.Instance.MoneySet();
            RivalD.Instance.fieldPrice.archerShot = (int)(RivalD.Instance.fieldPrice.characterSpeed * RivalD.Instance.fieldPriceFactor.characterSpeed);
            RivalD.Instance.factor.characterSpeed++;
            _characterSpeedPriceText.text = "Price : " + RivalD.Instance.fieldPrice.characterSpeed;
            GameStart.Instance.SetArcherArrowSpeedFactor();
            _characterSpeedText.text = RivalD.Instance.field.characterSpeed.ToString();
        }
    }

    public void MarketSelected()
    {
        for (int i = 0; i < _marketSelectedButton.Count; i++)
        {
            if (i == GameStart.Instance.MarketSelectWindow)
            {
                _marketSelectedGame[i].SetActive(true);
                continue;
            }
            _marketSelectedGame[i].SetActive(false);
        }
    }

    public void StartButton()
    {
        GameStart.Instance.gameStart = true;
        GameStart.Instance.inFight = false;
        _startGame.SetActive(false);
    }

    private void SettingButton()
    {
        _settingGame.SetActive(true);
        _GlobalGame.SetActive(false);
        if (GameStart.Instance.inFinish == true)
        {
            finishGame.SetActive(false);
        }
        if (GameStart.Instance.gameStart == true)
        {
            _startGame.SetActive(false);
        }

    }

    private void SettingBackButton()
    {
        _settingGame.SetActive(false);
        _GlobalGame.SetActive(true);
        if (GameStart.Instance.inFinish == true)
        {
            finishGame.SetActive(true);
        }
        if (GameStart.Instance.gameStart == true)
        {
            _startGame.SetActive(false);
        }
    }

    private void SoundButton()
    {
        if (GameStart.Instance.sound == 1)
        {
            GameStart.Instance.sound = 0;
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
            SoundSystem.Instance.MainMusicStop();
            GameStart.Instance.SetSound();
        }
        else
        {
            GameStart.Instance.sound = 1;
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            SoundSystem.Instance.MainMusicPlay();
            GameStart.Instance.SetSound();
        }
    }

    private void VibrationButton()
    {
        if (GameStart.Instance.vibration == 1)
        {
            GameStart.Instance.vibration = 0;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
            GameStart.Instance.SetVibration();
        }
        else
        {
            GameStart.Instance.vibration = 1;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
            GameStart.Instance.SetVibration();
        }
    }

    private void FinishButton()
    {
        SceneManager.LoadScene(0);
    }

    private void FailResumeButton()
    {
        //reklam
    }

    private void FailRetryButton()
    {
        SceneManager.LoadScene(0);
    }

    private void OpenChest()
    {
        int count = Random.Range(0, 10);
        if (count % 2 == 0)
        {
            chestChoseGame.SetActive(false);
            openChestGame.SetActive(true);
            _chestImage1.gameObject.SetActive(true);
            count = Random.Range(50, 100);
            _chestMoney.text = "+ " + count;
            GameStart.Instance.money += count;
            GameStart.Instance.MoneySet();
        }
        else
        {
            chestChoseGame.SetActive(false);
            openChestGame.SetActive(true);
            _chestImage2.gameObject.SetActive(true);
            count = Random.Range(30, 60);
            _chestMoney.text = "+ " + count;
            GameStart.Instance.money += count;
            GameStart.Instance.MoneySet();
        }
    }

    private void RewardOpen()
    {
        marketGame.SetActive(false);
        mainChestGame.SetActive(true);
        chestChoseGame.SetActive(true);
    }

    private void RewardLastButton()
    {
        mainChestGame.SetActive(false);
        openChestGame.SetActive(false);
        chestChoseGame.SetActive(true);
        marketGame.SetActive(true);
    }

    private void BackToTheGame()
    {
        GameStart.Instance.lastOne = false;
        GameStart.Instance.inFight = false;
        marketGame.SetActive(false);
    }
}
