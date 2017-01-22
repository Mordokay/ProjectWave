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
            life--;
            if (life <= 0)
            {
                GameObject newAsteroid1 = null;
                GameObject newAsteroid2 = null;

                    if (Random.Range(0, 2) == 0)
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        newAsteroid1 = Instantiate(Expelir, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }
                    else
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        newAsteroid1 = Instantiate(Item, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }

                    if (Random.Range(0, 2) == 0)
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        newAsteroid2 = Instantiate(Expelir, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }
                    else
                    {
                        Vector2 randomPos = Random.insideUnitCircle * 1;
                        newAsteroid2 = Instantiate(Item, transform.position + new Vector3(randomPos.x, randomPos.y, 0.0f), transform.rotation);
                    }

                newAsteroid1.GetComponent<Rigidbody2D>().velocity = new Vector2(-gameObject.GetComponent<Rigidbody2D>().velocity.x, -gameObject.GetComponent<Rigidbody2D>().velocity.y);
                newAsteroid2.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -gameObject.GetComponent<Rigidbody2D>().velocity.y);


                Destroy(gameObject);
            }
            
        }
    }
}
