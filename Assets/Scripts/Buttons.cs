using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoSingleton<Buttons>
{
    [SerializeField] private GameObject money;

    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _startGame;
    public bool inGame;

    [SerializeField] private Button _settingButton;
    [SerializeField] private GameObject _settingGame;

    [SerializeField] private Sprite _red, _green;
    [SerializeField] private Button _settingBackButton;
    public bool sound, vibration;
    [SerializeField] private Button _soundButton, _vibrationButton;

    [SerializeField] private Button _archerArrowSpeedFactorPlus, _archerShotFactorPlus, _characterSpeedFactorPlus;

    [SerializeField] private Button _continueButton;
    public GameObject continueGame;
    public bool inFinish;


    private void Start()
    {
        _startButton.onClick.AddListener(StartButton);
        _settingButton.onClick.AddListener(SettingButton);
        _settingBackButton.onClick.AddListener(SettingBackButton);
        _soundButton.onClick.AddListener(SoundButton);
        _vibrationButton.onClick.AddListener(VibrationButton);
        _continueButton.onClick.AddListener(ContinueButton);
        _archerArrowSpeedFactorPlus.onClick.AddListener(ArcherArrowSpeedFactorPlus);
        _archerShotFactorPlus.onClick.AddListener(ArcherShotFactorPlus);
        _characterSpeedFactorPlus.onClick.AddListener(CharacterSpeedFactorPlus);

        if (GameStart.Instance.sound == 1)
        {
            sound = true;
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            SoundSystem.Instance.MainMusicPlay();
        }
        else
        {
            sound = false;
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
        }

        if (GameStart.Instance.vibration == 1)
        {
            vibration = true;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
        }
        else
        {
            vibration = false;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
        }
    }

    private void ArcherArrowSpeedFactorPlus()
    {
        RivalD.Instance.archerArrowSpeedFactor++;
        GameStart.Instance.SetArcherArrowSpeedFactor();
    }

    private void ArcherShotFactorPlus()
    {
        RivalD.Instance.archerShotFactor++;
        GameStart.Instance.SetArcherShotFactor();
    }

    private void CharacterSpeedFactorPlus()
    {
        RivalD.Instance.characterSpeedFactor++;
        GameStart.Instance.SetCharacterSpeedFactor();
    }

    private void StartButton()
    {

    }

    private void SettingButton()
    {
        _settingGame.SetActive(true);
        _settingButton.gameObject.SetActive(false);
        money.SetActive(false);
        _startButton.gameObject.SetActive(false);
        if (inFinish == true)
        {
            continueGame.SetActive(false);
        }
        if (inGame == true)
        {
            _startGame.SetActive(false);
        }

    }

    private void SettingBackButton()
    {
        _settingGame.SetActive(false);
        _settingButton.gameObject.SetActive(true);
        money.SetActive(true);
        _startButton.gameObject.SetActive(true);
        if (inFinish == true)
        {
            continueGame.SetActive(true);
        }
        if (inGame == true)
        {
            _startGame.SetActive(false);
        }
    }

    private void SoundButton()
    {
        if (sound == true)
        {
            sound = false;
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
            SoundSystem.Instance.MainMusicStop();
            GameStart.Instance.sound = 0;
            GameStart.Instance.SetSound();
        }
        else
        {
            sound = true;
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            SoundSystem.Instance.MainMusicPlay();
            GameStart.Instance.sound = 1;
            GameStart.Instance.SetSound();
        }
    }

    private void VibrationButton()
    {
        if (vibration == true)
        {
            vibration = false;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
            GameStart.Instance.vibration = 0;
            GameStart.Instance.SetVibration();
        }
        else
        {
            vibration = true;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
            GameStart.Instance.vibration = 1;
            GameStart.Instance.SetVibration();
        }
    }

    private void ContinueButton()
    {
        SceneManager.LoadScene(0);
    }
}
