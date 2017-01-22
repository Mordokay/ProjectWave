using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expelir : MonoBehaviour {

    public bool isFired = false;
    PlayerStatsController stats;
    private GameObject explosionParticle;

	//sons:
	public AudioSource som;

    // Use this for initialization
    void Start () {
        stats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStatsController>();

        explosionParticle = Resources.Load("Explosion") as GameObject;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ShooterEnemy" && isFired)
        {
            Destroy(col.gameObject);
            stats.score += 1500;
			som.Play();
            isFired = false;
        }
        else if (col.gameObject.tag == "Bullet" && isFired)
        {
            Destroy(col.gameObject);
            //stats.score += 650;
            isFired = false;
        }
        else if (col.gameObject.tag == "Mine" && isFired)
        {
            Destroy(col.gameObject);
            stats.score += 900;
			som.Play();
            isFired = false;
        }
        else if (col.gameObject.tag == "Expelir" && isFired)
        {
            Destroy(col.gameObject);
            //stats.score += 300;
            isFired = false;
        }
        GameObject myParticle = Instantiate(explosionParticle);
        myParticle.transform.position = col.contacts[0].point;
        Destroy(myParticle, 5.0f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
