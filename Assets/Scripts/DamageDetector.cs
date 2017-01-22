using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour {

    PlayerStatsController stats;

    GameObject explosionParticle;


	//sons:
	public AudioSource som;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStatsController>();
        explosionParticle = Resources.Load("Explosion") as GameObject;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Mine")
        {
            Destroy(col.gameObject);
            stats.life -= 20.0f;
            GameObject myParticle = Instantiate(explosionParticle);
            myParticle.transform.position = col.contacts[0].point;
            Destroy(myParticle, 5.0f);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            stats.life -= 5.0f;
        }
        else if (col.gameObject.tag == "Expelir")
        {
            Destroy(col.gameObject);
            stats.life -= 10.0f;
        }
        else if (col.gameObject.tag == "Asteroid")
        {
            stats.life -= 20.0f;
        }

		som.Play();
    }

    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            stats.life -= 5.0f;
        }
    }
    */
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
