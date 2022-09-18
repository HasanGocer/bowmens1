using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoSingleton<GameStart>
{
    public bool gameStart;

    public int vibration, sound;

    private void Start()
    {
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
    }

    private void Update()
    {
        //oyun baþlatýr oyun sonunda ekrana tam buton koy ona týklayýnca gameStart true
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameStart = true;
            RivalWalk.Instance.inFight = false;
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
}
