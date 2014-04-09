using UnityEngine;
using System.Collections;

public class GenericSelfDestruct : MonoBehaviour {

	public float duration = 1f;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, duration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
