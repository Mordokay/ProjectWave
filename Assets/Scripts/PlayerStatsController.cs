using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour {

    public float life;
	public float healthIncreaseRate;
    public float powerIncreaseRate;
    public float power;
    public float powerDecreaseFactor;
    public float powerDecreaseHoldFactor;

    public int score;

    public GameObject healthBar;
    public GameObject powerBar;
    public Text scoreText;


    void Start () {
        score = 0;
        power = 100.0f;
    }
	
    public void DecreasePower()
    {
        power -= Time.deltaTime * powerDecreaseFactor;
    }

    public void DecreaseHoldPower()
    {
        power -= Time.deltaTime * powerDecreaseHoldFactor;
    }

    void Update () {
        scoreText.text = "SCORE: " + score;

        healthBar.GetComponent<Image>().fillAmount = life / 100.0f;
        powerBar.GetComponent<Image>().fillAmount = power / 100.0f;

        power += Time.deltaTime * powerIncreaseRate;
        life += Time.deltaTime * healthIncreaseRate;

        power = Mathf.Clamp(power, 0.0f, 100.0f);
        life = Mathf.Clamp(life, 0.0f, 100.0f);
    }
}
