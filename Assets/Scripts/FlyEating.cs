using UnityEngine;
using System.Collections;

public class FlyEating : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Fly")
		{
			Debug.Log("eating fly");
			other.transform.parent.GetComponent<Fly>().die();
			this.transform.parent.GetComponent<Player>().eat();
		}
	}

}
