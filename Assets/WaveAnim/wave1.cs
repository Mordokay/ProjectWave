﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave1 : MonoBehaviour {

	public bool emFrente;
	public bool aumentar;

	void Start () {
		StartCoroutine(Desaparecer());
	}

	IEnumerator Desaparecer(){
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

	void Update() {
		Color mycolor = gameObject.GetComponent<SpriteRenderer>().color;

		if(emFrente){

			transform.Translate(Vector3.up * Time.deltaTime * 3);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(mycolor.r, mycolor.g, mycolor.b, mycolor.a - Time.deltaTime);
			transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 0.3f, transform.localScale.y + Time.deltaTime * 0.7f, transform.localScale.z + Time.deltaTime * 0.5f);
		}

		if(aumentar){ // buraco negro

			transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * 0.5f, transform.localScale.y - Time.deltaTime * 0.5f, transform.localScale.z - Time.deltaTime * 0.5f);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(mycolor.r, mycolor.g, mycolor.b, mycolor.a + Time.deltaTime * 0.3f);
		}
	}
}
