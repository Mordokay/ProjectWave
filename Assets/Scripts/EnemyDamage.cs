using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public GameObject Expelir;
    public GameObject Item;

    public int life = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseLife()
    {
        life--;
        if (life <= 0)
        {
            if (Random.Range(0, 2) == 0)
            {

                GameObject newAsteroid1 = Instantiate(Expelir, transform.position, transform.rotation);
            }
            else
            {

                GameObject newAsteroid1 = Instantiate(Item, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Expelir" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 2.0f)
        {
            life--;
            if (life <= 0)
            {
                if (Random.Range(0, 2) == 0)
                {

                    GameObject newAsteroid1 = Instantiate(Expelir, transform.position, transform.rotation);
                }
                else
                {

                    GameObject newAsteroid1 = Instantiate(Item, transform.position, transform.rotation);
                }

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Mine" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 2.0f)
        {
            life--;
            if (life <= 0)
            {
                if (Random.Range(0, 2) == 0)
                {

                    GameObject newAsteroid1 = Instantiate(Expelir, transform.position, transform.rotation);
                }
                else
                {

                    GameObject newAsteroid1 = Instantiate(Item, transform.position, transform.rotation);
                }

                collision.gameObject.GetComponent<EnemyDamage>().LoseLife();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        
    }
}
