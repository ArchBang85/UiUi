using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector3 direction;
	public float power = 1.0f;
	public float speed = 15f;
	private float kickSpeedLeft = 50f; 
	private float kickSpeedRight = 50f;

	private float leftCooldown = 2f;
	private float rightCooldown = 2f;
	private float cooldownReset = 0.6f;

	public GameObject leftLeg;
	public GameObject rightLeg;
	public GameObject leftLegOut;
	public GameObject rightLegOut;
	


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		leftCooldown -= Time.deltaTime;
		rightCooldown -= Time.deltaTime;

		if (Input.GetKey("q")){
			if (leftCooldown < 0){
				leftCooldown = cooldownReset;
				// Left leg twitch
				ExtendLeftLeg();
				transform.rigidbody.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
				transform.rigidbody.AddRelativeForce(Vector3.right * power / 3, ForceMode.Impulse);
				// rotate a bit too
				transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * kickSpeedLeft);
			}
		}
		if (Input.GetKey("e")){
			if (rightCooldown < 0)
			{
				rightCooldown = cooldownReset;
				// Right leg twitch
				ExtendRightLeg();
				transform.rigidbody.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
				transform.rigidbody.AddRelativeForce(Vector3.left * power / 3, ForceMode.Impulse);
				transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * kickSpeedRight);
				
			}
		}

		//if (Input.GetKey("w")){
		//	transform.rigidbody.AddForce(Vector3.forward * power, ForceMode.Impulse);
		//}
		if (Input.GetKey("a")){
			transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
		}

		//if (Input.GetKey("s")){
		//	transform.rigidbody.AddForce(-Vector3.forward * power, ForceMode.Impulse);
		//}

		if (Input.GetKey("d")){
			transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
		}

	}

	void ExtendLeftLeg(){
		leftLeg.transform.renderer.enabled = false;
		leftLegOut.transform.renderer.enabled = true;
		StartCoroutine(restoreLeftLeg ());

	}

	void ExtendRightLeg(){
		rightLeg.transform.renderer.enabled = false;
		rightLegOut.transform.renderer.enabled = true;
		StartCoroutine(restoreRightLeg ());
		
	}

	IEnumerator restoreLeftLeg()
	{
		float duration = 0.6f;
		yield return new WaitForSeconds(duration);
		leftLeg.transform.renderer.enabled = true;
		leftLegOut.transform.renderer.enabled = false;
	}
	IEnumerator restoreRightLeg()
	{
		float duration = 0.6f;
		yield return new WaitForSeconds(duration);
		rightLeg.transform.renderer.enabled = true;
		rightLegOut.transform.renderer.enabled = false;
	}
	
}
