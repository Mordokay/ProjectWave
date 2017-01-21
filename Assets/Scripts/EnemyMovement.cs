using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Transform target;
    public float speed;
    public float minDistance;
    private float range;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Wander", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
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

    void Wander()
    {
        range = Vector2.Distance(this.transform.position, target.position);

        if (range > minDistance)
        {
            float randomX = Random.Range(-2.0f, 2.0f); // with float parameters, a random float
            float randomY = Random.Range(-2.0f, 2.0f); //  between -2.0 and 2.0 is returned
            direction = new Vector3(randomX, randomY,0.0f);
        }
    }
}
