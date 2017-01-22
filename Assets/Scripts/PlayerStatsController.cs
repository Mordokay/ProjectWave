using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour {

    public float life;
	public float healthIncreaseRate;
    public float powerIncreaseRate;
    public float power;
    public float powerDecreaseFactor;
    public float powerDecreaseHoldFactor;

    public int score;

	// high score
	public int highScore;

    public GameObject healthBar;
    public GameObject powerBar;
    public Text scoreText;
	public Text highScoreText;

    public GameObject panel;

    public bool powerOnCooldown;

    void Start () {
        score = 0;
        power = 100.0f;
    }
	
    public void DecreasePower()
    {
        powerOnCooldown = false;
        power -= Time.deltaTime * powerDecreaseFactor;
    }

    public void DecreaseHoldPower()
    {
        power -= Time.deltaTime * powerDecreaseHoldFactor;
    }

    public void checkPower()
    {
        if(power < 25)
        {
            powerOnCooldown = true;
        }
    }

    void Update () {

        if(life <= 0)
        {
            
			if(score <= highScore) {

				highScore = PlayerPrefs.GetInt("HighScore");
			}
			else {
				PlayerPrefs.SetInt("HighScore",score);
			}

			Time.timeScale = 0.0f;
            panel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(power > 25)
        {
            powerOnCooldown = false;
        }

        scoreText.text = "SCORE: " + score;
		highScoreText.text = "HIGHSCORE: " + highScore;

		highScore = PlayerPrefs.GetInt("HighScore");

        healthBar.GetComponent<Image>().fillAmount = life / 100.0f;
        powerBar.GetComponent<Image>().fillAmount = power / 100.0f;

        power += Time.deltaTime * powerIncreaseRate;
        life += Time.deltaTime * healthIncreaseRate;

        power = Mathf.Clamp(power, 0.0f, 100.0f);
        life = Mathf.Clamp(life, 0.0f, 100.0f);

        if (power == 0.0f)
        {
            powerOnCooldown = true;
        }
    }
}
