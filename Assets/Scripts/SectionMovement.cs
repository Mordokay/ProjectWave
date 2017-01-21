using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionMovement : MonoBehaviour {

    public bool lateral;
    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (lateral)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = new Vector3( Mathf.Clamp(transform.position.x, -18, 18), transform.position.y, transform.position.z);
        }
        else{
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20, 20), transform.position.z);
        }
	}
}
