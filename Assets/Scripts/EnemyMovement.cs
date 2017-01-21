using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    public float speed;
    public float minDistance;
    private float range;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(this.transform.position, target.position);

        if (range < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
