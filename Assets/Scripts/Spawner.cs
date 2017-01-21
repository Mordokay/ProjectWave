using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner : MonoBehaviour {

    float timeToNextSpawn;
    float elapsedTime;
    float spawnDecreaseTimeRatio;
    public List<spawnPoint> mySpawns;

    public List<GameObject> mySpawnables;

    public float speedMinVal;
    public float speedMaxVal;

    void Start()
    {
        elapsedTime = 999.0f;
        timeToNextSpawn = 0.5f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeToNextSpawn)
        {
            GameObject myEnemy = Instantiate(mySpawnables[Random.Range(0, mySpawnables.Count)]) as GameObject;
            spawnPoint myPoint = mySpawns[Random.Range(0, mySpawns.Count)];
            myEnemy.transform.position = myPoint.originPoint.position;
            myEnemy.GetComponent<Rigidbody2D>().velocity = (myPoint.directionPoint.position - myPoint.originPoint.position).normalized * Random.Range(speedMinVal, speedMaxVal);
            elapsedTime = 0.0f;
        }
    }

    [System.Serializable]
    public class spawnPoint
    {

        public Transform originPoint;
        public Transform directionPoint;
    }
	
    void Spawn()
    {

    }
}