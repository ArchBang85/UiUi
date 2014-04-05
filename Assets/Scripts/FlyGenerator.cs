using UnityEngine;
using System.Collections;

public class FlyGenerator : MonoBehaviour {

	public float radiusX = 25.0f;
	public float radiusZ = 12.0f;

	public float innerSpaceRadius = 5.0f;

	public int amount = 12;
	public GameObject fly;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < amount; i++)
		{
			GameObject flyUnit;

			float xPos = Random.Range (-radiusX, radiusX + 1);
			float zPos = Random.Range (-radiusZ, radiusZ + 1);
			while (xPos > -innerSpaceRadius && xPos < innerSpaceRadius && zPos > -innerSpaceRadius && zPos < innerSpaceRadius)
			{
				xPos = Random.Range (-radiusX, radiusX + 1); // reroll so it doesn't go too close to the start point
				zPos = Random.Range (-radiusZ, radiusZ + 1); // reroll so it doesn't go too close to the start point
			}

			Vector3 spawnPosition = new Vector3(xPos, 5, zPos);
			flyUnit = Instantiate (fly, spawnPosition, Quaternion.identity) as GameObject;
			flyUnit.transform.Rotate (90,Random.Range(0, 360),0,Space.World);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
