using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour {

    private bool isPressing;
    private bool toFire;

    public Transform RangeCenter;
    

    public GameObject Ammo;

	// Use this for initialization
	void Start () {

        GetComponent<PolygonCollider2D>().enabled = false;
        isPressing = false;
        toFire = false;
        Ammo = null;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
        {
            isPressing = true;
            GetComponent<PolygonCollider2D>().enabled = true;
        }
        else
        {
            isPressing = false;
            GetComponent<PolygonCollider2D>().enabled = false;

            if (toFire && Ammo)
            {
                
                Vector2 vec = Ammo.transform.position - gameObject.transform.position;
                Ammo.GetComponent<Rigidbody2D>().AddForce(-vec * Random.Range(1000, 1500));
                toFire = false;
                Ammo = null;
            }
            

        }

	}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Expelir" && Ammo == null)
        {
            Ammo = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Expelir" && Ammo != null)
        {
            Ammo = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Items" && isPressing)
        {
            if(Vector2.Distance(collision.gameObject.transform.position, RangeCenter.position) <= 0.8f)
            {
                Destroy(collision.gameObject);
            }
            collision.transform.position = Vector2.Lerp(collision.transform.position, RangeCenter.position, 6 * Time.deltaTime);
        }

        if (Ammo != null && isPressing)
        {
            if (Vector2.Distance(Ammo.transform.position, RangeCenter.position) <= 0.8f)
            {
                Ammo.transform.position = RangeCenter.position;
                toFire = true;
            }
            else
            {
                Ammo.transform.position = Vector2.Lerp(Ammo.transform.position, RangeCenter.position, 6 * Time.deltaTime);
            }
            
        }
        
    }
}
