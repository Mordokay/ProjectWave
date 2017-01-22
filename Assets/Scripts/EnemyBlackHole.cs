using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackHole : MonoBehaviour {

	public GameObject musicObject;
	public Transform player;

    private PlayerStatsController stats;

    public Transform wave;

	// Use this for initialization
	void Start () {
        stats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStatsController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
		musicObject = GameObject.Find("Music");
		musicObject.GetComponent<AudioSource>().pitch = 1;

		StartCoroutine(Tempo1());
	}

	IEnumerator Tempo1(){
		while(true){
			yield return new WaitForSeconds(0.7f);
			Transform newWave = Instantiate(wave, transform.position, transform.rotation) as Transform;
			newWave.gameObject.GetComponent<wave1>().aumentar = true;
		}
	}

	// Update is called once per frame
	void Update () {

		float dist = Vector2.Distance(this.transform.position, player.position);
		if(Mathf.Abs(dist) < 4 && musicObject.GetComponent<AudioSource>().pitch > 0.8){
			
			musicObject.GetComponent<AudioSource>().pitch -= 0.1f * Time.deltaTime;
			player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 2 * Time.deltaTime);
			player.transform.RotateAround(transform.position,Vector3.forward,50*Time.deltaTime);
		}
		else if(musicObject.GetComponent<AudioSource>().pitch < 1 && Mathf.Abs(dist) < 8 && Mathf.Abs(dist) >= 4){
			musicObject.GetComponent<AudioSource>().pitch += 0.3f * Time.deltaTime;
		}

		if(Mathf.Abs(dist) < 0.5)
        {
            stats.life = 0;
        }

	}
}
