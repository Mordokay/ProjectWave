using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaker : MonoBehaviour {

	public int tempo;
	public bool animar;
	public Transform wave;
	PlayerStatsController stats;

	// Use this for initialization
	void Start () {
		stats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStatsController>();
	}

	IEnumerator Tempo1(){
		while(animar){
			yield return new WaitForSeconds(0.2f);
			Transform newWave = Instantiate(wave, transform.position, transform.rotation) as Transform;
			newWave.gameObject.GetComponent<wave1>().emFrente = true;
		}
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && !stats.powerOnCooldown){
			if(animar == false){
				animar = true;
				StartCoroutine(Tempo1());
			}
				
		}
		else{
			animar = false;
		}
	}
}
