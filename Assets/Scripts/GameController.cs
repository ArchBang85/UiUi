using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] playerSpawns;
	public bool allowSpawn = true;
	

	// Use this for initialization
	void Start () {

		playerSpawns = GameObject.FindGameObjectsWithTag("Spawn");

	}
	
	// Update is called once per frame
	void Update () {
		if(allowSpawn){
			foreach (GameObject spawnPoint in playerSpawns){
				Debug.Log (spawnPoint.transform.position);
			}
			allowSpawn = false;
		}
	}
}
