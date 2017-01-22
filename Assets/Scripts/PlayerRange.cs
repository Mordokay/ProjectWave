using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{

    public Transform RangeCenter;

    public bool isPressing;

    private bool isMine = false;

    private GameObject Ammo;
    public GameObject distortion;
    PlayerStatsController stats;


	//sons:
	public AudioClip somAbsorver;
	public AudioClip somRepulsar;
	public AudioClip somGem;
	public AudioSource som;


    // Use this for initialization
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStatsController>();
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        distortion.SetActive(false);
        isPressing = false;
        Ammo = null;

		//som:
		som = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.powerOnCooldown)
        {
            if (Ammo != null)
            {
                stats.DecreaseHoldPower();
            }
            else if (isPressing)
            {
                stats.DecreasePower();
            }
        }

        if (Input.GetMouseButton(0) && !stats.powerOnCooldown)
        {
            isPressing = true;
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<PolygonCollider2D>().enabled = true;
            distortion.SetActive(true);

        }
        else
        {
            stats.checkPower();

            distortion.SetActive(false);
            this.GetComponent<PolygonCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            isPressing = false;
            if(Ammo != null)
            {

				som.clip = somRepulsar;
				som.pitch = 1.4f;
				som.volume = 1;
				som.Play();

                if(!isMine)
                {
                    Ammo.GetComponent<Expelir>().isFired = true;
                }
                else
                {
                    Ammo.GetComponent<MineController>().isAmmo = false;
                }
                Vector2 vec = Ammo.transform.position - gameObject.transform.position;
                Ammo.GetComponent<Rigidbody2D>().AddForce(vec * 45000);
                Ammo = null;
                isMine = false;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Expelir" && isPressing)
        {
            Ammo = null;
        }
        if (collision.tag == "Mine" && isPressing)
        {
            isMine = false;
            collision.gameObject.GetComponent<MineController>().isAmmo = false;
            Ammo = null;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Items" && isPressing)
        {
            if (Vector2.Distance(collision.gameObject.transform.position, gameObject.transform.position) <= 1.0f)
            {
                Destroy(collision.gameObject);
                stats.score += 500;

				som.clip = somGem;
				som.pitch = 1;
				som.volume = 0.4f;
				som.Play();
            }
            collision.transform.position = Vector2.Lerp(collision.transform.position, gameObject.transform.position, 6 * Time.deltaTime);
        }

        if(collision.tag == "Expelir" && isPressing)
        {
           if(Ammo == null)
           {
                if (Vector2.Distance(collision.transform.position, gameObject.transform.position) <= 0.4f)
                {
                    collision.transform.position = RangeCenter.position;
                    Ammo = collision.gameObject;

					som.clip = somAbsorver;
					som.pitch = 1.4f;
					som.volume = 1;
					som.Play();
                }
                collision.transform.position = Vector2.Lerp(collision.transform.position, gameObject.transform.position, 6 * Time.deltaTime);
           }
           else
           {
                Ammo.transform.position = RangeCenter.position;
           }

        }

        if (collision.tag == "Mine" && isPressing)
        {
            if (Ammo == null)
            {
                if (Vector2.Distance(collision.transform.position, gameObject.transform.position) <= 0.4f)
                {
                    collision.transform.position = RangeCenter.position;
                    collision.gameObject.GetComponent<MineController>().isAmmo = true;
                    isMine = true;
                    Ammo = collision.gameObject;

					som.clip = somAbsorver;
					som.pitch = 1.4f;
					som.volume = 1;
					som.Play();
                }
                collision.transform.position = Vector2.Lerp(collision.transform.position, gameObject.transform.position, 6 * Time.deltaTime);
            }
            else
            {
                Ammo.transform.position = RangeCenter.position;
            }

        }
    }


}
