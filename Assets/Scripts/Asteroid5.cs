using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid5 : MonoBehaviour {


    private Vector3 movePosition;

    public int life = 1;

    // Use this for initialization
    void Start () {
        
        movePosition = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePosition, 0.5f * Time.deltaTime);
        if (movePosition == gameObject.transform.position)
        {
            movePosition = Random.insideUnitCircle * 3;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Expelir" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 2.0f)
        {

            //float scale = transform.localScale.x * 0.8f;
            //transform.localScale = new Vector3(scale, scale, scale);
            life--;
            if (life <= 0)
            {

                CircleCollider2D[] colliders = gameObject.GetComponentsInChildren<CircleCollider2D>();
                foreach(CircleCollider2D col in colliders)
                {
                    col.enabled = true;
                }

                transform.DetachChildren();


                Destroy(gameObject);
            }
        }
    }
}
