using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	public GameObject[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// find greatest distance from 0,0,0
		bool found = false;
		float farPoint = 0;
		foreach (GameObject player in players){
			Vector3 p = player.transform.position;
			if(p.magnitude > farPoint)
			{
				farPoint = p.magnitude;
				found = true;
			}
			if(!found)
			{
				farPoint = 0;
			}

		}

		this.camera.orthographicSize = 12 + farPoint * 0.75f;

	}
}
