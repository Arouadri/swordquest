using UnityEngine;
using System.Collections;

public class RespawnEnemies : MonoBehaviour {

    public GameObject enemy;        //el enemigo que sera respawneado
    public float spawnTime = 3f;   //tiene entre respawns
    public Transform[] spawnPoints; //donde el enemigo puede ser respawneado


	// Use this for initialization
	void Start () {
        //spawnPoints = new Transform[3];
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
        
        int spawnPointIndex = Random.Range(0,spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position,spawnPoints[spawnPointIndex].rotation);
        //enemy.enabled = true;
    }
}
