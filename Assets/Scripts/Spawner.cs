using System.Collections;
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
        public float probability;
    }

    void Start()
    {
        elapsedTime = 999.0f;
        timeToNextSpawn = 2.0f;
        InvokeRepeating("DecreaseSpawnTime", 0.0f, 3.0f);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeToNextSpawn)
        {
            int spawnableIndex;
            while (true) {
                float rand = Random.Range(0.0f, 1.0f);
                spawnableIndex = Random.Range(0, mySpawnables.Count);
                if (mySpawnables[spawnableIndex].probability >= rand)
                    break;
            }
            
            GameObject myEnemy = Instantiate(mySpawnables[spawnableIndex].specificObject) as GameObject;
            spawnPoint myPoint = mySpawns[Random.Range(0, mySpawns.Count)];
            myEnemy.transform.position = myPoint.originPoint.position;

            float spd = 0;
            foreach(SceneObject go in mySpawnables)
            {
                if(go.specificObject == myEnemy)
                {
                    spd = go.speed;
                    break;
                }
            }

            myEnemy.GetComponent<Rigidbody2D>().velocity = (myPoint.directionPoint.position - myPoint.originPoint.position).normalized * spd;
            elapsedTime = 0.0f;
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