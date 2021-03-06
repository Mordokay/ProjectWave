﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner : MonoBehaviour {

    public float timeToNextSpawn;
    float elapsedTime;
    public float spawnDecreaseTimeRatio;
    public List<spawnPoint> mySpawns;

    //public List<GameObject> mySpawnables;

    public List<SceneObject> mySpawnables;

    public float speedMinVal;
    public float speedMaxVal;

    [System.Serializable]
    public class SceneObject
    {
        public GameObject specificObject;
        public float speed;
        public float minProbability;
        public float maxProbability;
    }

    void Start()
    {
        elapsedTime = 999.0f;
        InvokeRepeating("DecreaseSpawnTime", 0.0f, 3.0f);
    }

    GameObject whatToSpawn(float randomProb)
    {
        GameObject myEnemy = null;
        foreach (SceneObject obj in mySpawnables)
        {
            if (randomProb >= obj.minProbability && randomProb < obj.maxProbability)
            {
                myEnemy = Instantiate(obj.specificObject) as GameObject;
                spawnPoint myPoint = mySpawns[Random.Range(0, mySpawns.Count)];

                myEnemy.transform.position = myPoint.originPoint.position;

                myEnemy.GetComponent<Rigidbody2D>().velocity = (myPoint.directionPoint.position - myPoint.originPoint.position).normalized * obj.speed;
                elapsedTime = 0.0f;

                return myEnemy;
            }
        }
        return null;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeToNextSpawn)
        {
            float randomProb = Random.Range(0.0f, 1.0f);
            float randomInt = Random.Range(0.0f, 1.0f);

            for(int i = 0; i<mySpawns.Count; i++)
            {
                if (randomInt == 0)
                {
                    if (i % 2 == 0)
                    {
                        whatToSpawn(randomProb);
                    }
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        whatToSpawn(randomProb);
                    }
                }
            }
            
        }
    }

    [System.Serializable]
    public class spawnPoint
    {

        public Transform originPoint;
        public Transform directionPoint;
    }
	
    void DecreaseSpawnTime()
    {
        timeToNextSpawn -= spawnDecreaseTimeRatio;
    }
}