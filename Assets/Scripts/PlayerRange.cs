﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{

    public Transform RangeCenter;

    private bool isPressing;

    private GameObject Ammo;
    public GameObject distortion;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        distortion.SetActive(false);
        isPressing = false;
        Ammo = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isPressing = true;
            this.GetComponent<SpriteRenderer>().enabled = true;
            distortion.SetActive(true);
        }
        else
        {
            distortion.SetActive(false);
            this.GetComponent<SpriteRenderer>().enabled = false;
            isPressing = false;
            if(Ammo != null)
            {
                Ammo.GetComponent<Expelir>().isFired = true;
                Vector2 vec = Ammo.transform.position - gameObject.transform.position;
                Ammo.GetComponent<Rigidbody2D>().AddForce(vec * 10000);
                Ammo = null;
            }
            
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Items" && isPressing)
        {
            
            if (Vector2.Distance(collision.gameObject.transform.position, gameObject.transform.position) <= 1.0f)
            {
                Destroy(collision.gameObject);
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
