using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector3 direction;
	public float power = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")){
			transform.rigidbody.AddForce(Vector3.forward * power, ForceMode.Impulse);
		}
		if (Input.GetKey("a")){
			transform.rigidbody.AddForce(Vector3.left * power, ForceMode.Impulse);
		}

		if (Input.GetKey("s")){
			transform.rigidbody.AddForce(-Vector3.forward * power, ForceMode.Impulse);
		}

		if (Input.GetKey("d")){
			transform.rigidbody.AddForce(Vector3.right * power, ForceMode.Impulse);
		}

	}
}
