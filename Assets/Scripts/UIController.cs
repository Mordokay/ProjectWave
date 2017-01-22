using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Sprite mutedButton;
    public Sprite unmutedButton;
    public bool muted;

    public Button Mutebutton;

    void Start()
    {
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            Mutebutton.image.overrideSprite = mutedButton;
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            Mutebutton.image.overrideSprite = unmutedButton;
            muted = false;
            AudioListener.pause = false;
        }
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene("MovementTest");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Mute()
    {
        if (muted)
        {
            PlayerPrefs.SetInt("muted", 0);
            muted = false;
            AudioListener.pause = false;
            Mutebutton.image.overrideSprite = unmutedButton;
        }
        else
        {
            PlayerPrefs.SetInt("muted", 1);
            muted = true;
            AudioListener.pause = true;
            Mutebutton.image.overrideSprite = mutedButton;
        }
    }
}
