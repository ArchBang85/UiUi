using UnityEngine;
using System.Collections;

public class Amble : MonoBehaviour {

	public float minX = -5.0f;
	public float minZ = -5.0f;
	public float maxX = 5.0f;
	public float maxZ = 5.0f;

	private float counter = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		//Debug.Log (counter);
		if (counter < 0)
		{

			float xDir = Random.Range (-10,11);
			float zDir = Random.Range (-10,11);

			if (this.transform.position.x < minX)
			{
				xDir = Mathf.Abs(xDir);
			}
			else if (this.transform.position.x > maxX)
			{
				xDir = -Mathf.Abs (xDir);
			}
			if (this.transform.position.z < minZ)
			{
				zDir = Mathf.Abs(zDir);
			}
			else if (this.transform.position.z > maxZ)
			{
				zDir = -Mathf.Abs (zDir);
			}

			Vector3 dir = new Vector3(xDir, 0, zDir);
			float power = Random.Range (1,30) / 10;
			transform.rigidbody.AddForce(dir.normalized * power, ForceMode.Impulse);
			//Debug.Log ("pushing to " + dir.normalized); 
			//Debug.Log ("power " + power); 
			counter = Random.Range (2,12);
		}

	
	}
}
