using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour {

    PlayerStatsController stats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStatsController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Mine")
        {
            Destroy(col.gameObject);
            stats.life -= 20.0f;
        }
        else if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            stats.life -= 5.0f;
        }
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
