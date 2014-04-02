using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	public float power = 0.3f;
	private float newDirCounter = 2.0f;
	private Vector3 direction;
	private Vector3 orientation;
	private Vector3 newRotation;
	// Use this for initialization
	void Start () {
	
		direction = RandomDirection();
		dashTo(direction);
		orientation = RandomDirection ();

	}
	
	// Update is called once per frame
	void Update () {
		newDirCounter -= Time.deltaTime;
		if (newDirCounter < 0){
			newDirCounter = Random.Range(30,75)/10;
			direction = RandomDirection();
			dashTo(direction);
		}
	}

	Vector3 RandomDirection(){

		return new Vector3(Random.Range (-1,2), 0, Random.Range (-1,2));

	}

	void dashTo(Vector3 direction){
		transform.rigidbody.AddForce(direction * power, ForceMode.Impulse);
		//newRotation = Quaternion.LookRotation(direction).eulerAngles;
		//newRotation.z = 0;
		//newRotation.x = 0;
		//transform.rotation = Quaternion.Euler(newRotation);
		//Quaternion newRotation = Quaternion.LookRotation(direction);
		//this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRotation, Time.deltaTime * 8);
	}
}
