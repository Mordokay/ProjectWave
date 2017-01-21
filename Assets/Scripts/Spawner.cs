using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner : MonoBehaviour {

    [System.Serializable]
    public class spawnPoint
    {

        public Transform originPoint;
        public Transform directionPoint;
    }

    public List<spawnPoint> mySpawns;

    void Start () {
        mySpawns = new List<spawnPoint>();
    }
	
	void Update () {
		
	}
}