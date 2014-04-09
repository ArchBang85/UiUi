using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] playerSpawns;
	public bool allowSpawn = true;
	public GameObject mainText;
	private float counter = 4.0f;
	private bool count = true;
	public int playerWon = 0;
	public int bugs = 13;
	public int bugsEaten = 0;
	// Use this for initialization
	void Start () {

		playerSpawns = GameObject.FindGameObjectsWithTag("Spawn");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(counter > 0 && count){
			counter -= Time.deltaTime;
		}
		if(counter < 0 && count){
			count = false;
			updateMainText ("");
		}
	
		if(allowSpawn){
			foreach (GameObject spawnPoint in playerSpawns){
				Debug.Log (spawnPoint.transform.position);
			}
			allowSpawn = false;
		}

		if(Input.GetKey("n")){
			Application.LoadLevel("main");
		}

		if(playerWon == 1){
			mainText.guiText.text = "Blue partied harder\nn to party more";
		}
		if(playerWon == 2){
			mainText.guiText.text = "Red partied harder\nn to party more";
		}
		if(bugs == bugsEaten){
			mainText.guiText.text = "Running low on party flies\nn to party more";
		}
		
	}

	public void updateMainText(string text)
	{
		mainText.guiText.text = text;
		counter = 3.0f;
		count = true;
	}
}
