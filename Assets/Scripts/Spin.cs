using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed = 1.0f;
	public int direction = -1; // 1 or -1
	private float counter;
	public bool RandomiseSpeed = true;
	
	// Use this for initialization
	void Start () {
		counter = 3;
		if(RandomiseSpeed){
			speed = Random.Range (100,200) / 10;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if(counter < 0){
			// change direction
			direction *= -1;
			counter = Random.Range (20,50)/10;
		}
		transform.Rotate (direction * Vector3.forward * Time.deltaTime * speed);
	}
}
