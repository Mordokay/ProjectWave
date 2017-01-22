using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public GameObject asteroidPrefab;
    public GameObject Expelir;
    public GameObject Item;

    private Vector3 movePosition;

    public int life = 5;

	// Use this for initialization
	void Start () {
        movePosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePosition, 0.5f * Time.deltaTime);
		if(movePosition == gameObject.transform.position)
        {
            movePosition = Random.insideUnitCircle * 3;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if((collision.gameObject.tag == "Expelir" || collision.gameObject.tag == "Mine") && collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 2.0f)
        {
            
            //float scale = transform.localScale.x * 0.8f;
            //transform.localScale = new Vector3(scale, scale, scale);
            if(life < 1)
            {
                if (transform.localScale.x * 0.6f > 0.5f)
                {
                    Vector2 randomPos = Random.insideUnitCircle * 1;
                    GameObject newAsteroid1 = Instantiate(asteroidPrefab, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    float scale = transform.localScale.x * 0.6f;
                    newAsteroid1.transform.localScale = new Vector3(scale, scale, scale);

                    randomPos = Random.insideUnitCircle * 1;
                    GameObject newAsteroid2 = Instantiate(asteroidPrefab, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    scale = transform.localScale.x * 0.6f;
                    newAsteroid2.transform.localScale = new Vector3(scale, scale, scale);
                }
                else
                {
                    if(Random.Range(0, 2) == 0)
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        GameObject newAsteroid1 = Instantiate(Expelir, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }
                    else
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        GameObject newAsteroid1 = Instantiate(Item, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }

                    if (Random.Range(0, 2) == 0)
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        GameObject newAsteroid2 = Instantiate(Expelir, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }
                    else
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        GameObject newAsteroid2 = Instantiate(Item, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }

                }


                Destroy(gameObject);
            }
            else
            {
                life--;
            }
        }
    }
}
