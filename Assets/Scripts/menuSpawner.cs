using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSpawner : MonoBehaviour {

    public List<Sprite> mySprites;
    public float elapsedTime;
    public float timeToNextSpawn;

    public List<spawnPoint> mySpawns;

    void Start()
    {
        elapsedTime = 0.0f;
    }

    void Update () {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > timeToNextSpawn)
        {
            spawnPoint myPoint = mySpawns[Random.Range(0, mySpawns.Count)];

            GameObject myObject = new GameObject();
            myObject.transform.position = myPoint.originPoint.position;
            myObject.AddComponent<Rigidbody2D>();
            myObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            myObject.GetComponent<Rigidbody2D>().velocity = (myPoint.directionPoint.position - myPoint.originPoint.position).normalized * 5.0f;
            myObject.AddComponent<SpriteRenderer>();
            myObject.GetComponent<SpriteRenderer>().sprite = mySprites[Random.Range(0, mySprites.Count)];

            elapsedTime = 0.0f;

            myObject.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
            Destroy(myObject, 8.0f);
        }
    }

    [System.Serializable]
    public class spawnPoint
    {

        public Transform originPoint;
        public Transform directionPoint;
    }
}
