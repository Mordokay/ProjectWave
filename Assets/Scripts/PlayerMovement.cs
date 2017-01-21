using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidB;

	// Use this for initialization
	void Start () {
        rigidB = gameObject.GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        Camera.main.transform.position = gameObject.transform.position + new Vector3(0,0, -10);
    }

   
	// Update is called once per frame
	void FixedUpdate () {
        
		if(Input.GetKey("w") && rigidB.velocity.y < 4)
        {
            rigidB.AddForce(Vector2.up * 40);
        }

        if (Input.GetKey("s") && rigidB.velocity.y > -4)
        {
            rigidB.AddForce(Vector2.up * -40);
        }

        if (Input.GetKey("a") && rigidB.velocity.x > -4)
        {
            rigidB.AddForce(Vector2.right * -40);
        }

        if (Input.GetKey("d") && rigidB.velocity.x < 4)
        {
            rigidB.AddForce(Vector2.right * 40);
        }
        
    }
}
