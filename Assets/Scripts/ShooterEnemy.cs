using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour {

    private Transform target;
    public float speed;
    public float distance;
    private float range;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;

    // Use this for initialization
    void Start () {
        InvokeRepeating("LaunchProjectile", 0.0f, 1.0f);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

	// Update is called once per frame
	void Update () {
        range = Vector2.Distance(this.transform.position, target.position);
        if (Mathf.Abs(range-distance) > 0.05f)
        {
            transform.position = Vector2.MoveTowards(transform.position, (transform.position - target.position).normalized * distance + target.position, speed * Time.deltaTime);
        }
        Vector3 diff = target.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot_z - 90.0f);
    }

    void LaunchProjectile()
    {
        if (Vector3.Distance(target.position, this.transform.position) < distance * 1.5f)
        {
            //TODO Shuold only launch when its close to the player
            GameObject myBullet = Instantiate(bullet);
            myBullet.transform.position = bulletSpawnPoint.position;
            myBullet.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * bulletSpeed;
        }
    }
}
