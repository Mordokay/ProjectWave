using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {

    private Transform target;
    public float speed;
    public float minDistance;
    private float range;
    private Vector3 direction;
    private GameObject explosionParticle;

    public bool isAmmo = false;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        explosionParticle = Resources.Load("Explosion") as GameObject;

        InvokeRepeating("Wander", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAmmo)
        {
            range = Vector2.Distance(this.transform.position, target.position);

            if (range < minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //TODO Expelir should make a rock particle explosion
        if (col.gameObject.tag == "ShooterEnemy" || col.gameObject.tag == "Bullet" || col.gameObject.tag == "Mine" || col.gameObject.tag == "Expelir")
        {
            Destroy(col.gameObject);
            GameObject myParticle = Instantiate(explosionParticle);
            myParticle.transform.position = col.contacts[0].point;
            Destroy(myParticle, 5.0f);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShooterEnemy" || col.gameObject.tag == "Bullet" || col.gameObject.tag == "Mine")
        {
            Destroy(col.gameObject);
            GameObject myParticle = Instantiate(explosionParticle);
            myParticle.transform.position = this.transform.position;
            Destroy(myParticle, 5.0f);
            Destroy(this.gameObject);
        }
    }

    void Wander()
    {
        if(!isAmmo)
        {
            range = Vector2.Distance(this.transform.position, target.position);

            if (range > minDistance)
            {
                float randomX = Random.Range(-2.0f, 2.0f); // with float parameters, a random float
                float randomY = Random.Range(-2.0f, 2.0f); //  between -2.0 and 2.0 is returned
                direction = new Vector3(randomX, randomY, 0.0f);
            }
        }
    }
}
