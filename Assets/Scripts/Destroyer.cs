using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
