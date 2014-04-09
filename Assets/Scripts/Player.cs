using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector3 direction;
	public int playerNumber = 1;
	public float power = 1.0f;
	public float speed = 15f;
	private float kickSpeedLeft = 500f; 
	private float kickSpeedRight = 500f;

	private float leftCooldown = 2f;
	private float rightCooldown = 2f;
	private float cooldownReset = 0.6f;

	public GameObject leftLeg;
	public GameObject rightLeg;
	public GameObject leftLegOut;
	public GameObject rightLegOut;

	public GameObject eatingHead;
	public GameObject[] head = new GameObject[2];
	public float headShotPower = 10.0f;

	public GameObject deathBurst;
	private Vector3 bodyForward;

	public int bugsEaten = 0;

	private bool invulnerable = false;
	private float iCount = 0.5f;
	public GameObject gameController;
	public Transform[] headSlots = new Transform[2];

	// Use this for initialization
	void Start () {
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		int i = 0;
		foreach (Transform child in allChildren)
		{
			//Debug.Log(child);
			if(child.gameObject.tag == "HeadSlot")
			{
				headSlots[i] = child;
				i++;
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
		leftCooldown -= Time.deltaTime;
		rightCooldown -= Time.deltaTime;

		bodyForward = Vector3.forward;

		if (iCount > 0)
		{
			iCount -= Time.deltaTime;
			invulnerable = true;
		} else {
			invulnerable = false;
		}

		// p1 controls

		if(playerNumber == 1)
		{
			if (Input.GetKey("z")){
				if (leftCooldown < 0){
					leftCooldown = cooldownReset;
					// Left leg twitch
					ExtendLeftLeg();
					transform.rigidbody.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
					transform.rigidbody.AddRelativeForce(Vector3.right * power, ForceMode.Impulse);
					// rotate a bit too
					transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * kickSpeedLeft);
				}
			}
			if (Input.GetKey("c")){
				if (rightCooldown < 0)
				{
					rightCooldown = cooldownReset;
					// Right leg twitch
					ExtendRightLeg();
					transform.rigidbody.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
					transform.rigidbody.AddRelativeForce(Vector3.left * power, ForceMode.Impulse);
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

			if (Input.GetKey("e")){
				fireHead("Right");
			}
			if (Input.GetKey("q")){
				fireHead("Left");
			}
		}
		else if (playerNumber == 2)
		{
			if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey ("j")){
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
			if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey ("l")){
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
			

			if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey ("u")){
				transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
			}
			
					
			if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey ("o")){
				transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
			}
			
			if (Input.GetKey(KeyCode.Keypad9) || Input.GetKey ("9")){
				fireHead("Right");
			}
			if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey ("7")){
				fireHead("Left");
			}
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

	public void eat()
	{
		Debug.Log("eating");
		// What happens with eating?
		// score increments
		bugsEaten++;
		gameController.GetComponent<GameController>().bugsEaten += 1;
		// Add a head
		addHead();


	}

	void addHead(){
		foreach (Transform slot in headSlots){
			bool occupied;
			occupied = slot.GetComponent<HeadSlot>().state();
			//Debug.Log(occupied);
			GameObject newHead;
			if(slot.GetComponent<HeadSlot>().state() == false)
			{
				Debug.Log("Adding head");

				int r = Random.Range (0,2);
				// Show the text
				if(r==0){
					gameController.GetComponent<GameController>().updateMainText("Rainer!");
				}
				else if (r==1){
				// Show the text
					gameController.GetComponent<GameController>().updateMainText("Rockefeller!");
				}

				newHead = Instantiate(head[r], slot.position, Quaternion.identity) as GameObject;
				newHead.transform.parent = slot;
				slot.GetComponent<HeadSlot>().flip();
				return;
			}
		}
	}

	void fireHead(string HeadName){

		GameObject headToFire;
		if(HeadName == "Right")
		{
			if(headSlots[0].GetComponent<HeadSlot>().state())
			{
				Debug.Log("Firing right head");
				// detach head from arm
				headSlots[0].GetComponent<HeadSlot>().flip();

				foreach(Transform child in headSlots[0])
				{
					child.parent = null;
					child.tag = "Head"; // make the head dangerous
					child.GetComponent<GenericSelfDestruct>().enabled = true;
					child.gameObject.AddComponent<Rigidbody>();
					child.gameObject.rigidbody.useGravity = false;
					child.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 
					//Debug.Log(transform.rotation * Vector3.forward);
					child.rigidbody.AddForce(transform.forward * headShotPower, ForceMode.Impulse);
				
				}

				invulnerable = true;
				iCount = 0.5f;

				// give head momentum

				// GetComponentsInChildren<Transform>();

			
			}
		}
		if(HeadName == "Left")
		{

			if(headSlots[1].GetComponent<HeadSlot>().state())
			{
				headSlots[1].GetComponent<HeadSlot>().flip();
				Debug.Log("Firing left head");
				foreach(Transform child in headSlots[1])
				{
					child.parent = null;
					child.tag = "Head"; // make the head dangerous
					child.GetComponent<GenericSelfDestruct>().enabled = true;
					child.gameObject.AddComponent<Rigidbody>();
					child.gameObject.rigidbody.useGravity = false;
					child.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 

					//Debug.Log(transform.rotation * Vector3.forward);
					child.rigidbody.AddForce(transform.forward * headShotPower, ForceMode.Impulse);//child.rigidbody.AddForce(Vector3.forward * 6, ForceMode.Impulse);
					
				}
				invulnerable = true;
				iCount = 0.5f;
			}
		}

	}

	void die()
	{
		foreach(Transform child in transform)
		{
			child.parent = null;
			child.gameObject.AddComponent<Rigidbody>();
			child.gameObject.rigidbody.useGravity = false;
			child.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 
			child.rigidbody.AddForce(Vector3.forward * 10, ForceMode.Impulse);
		}
		Destroy (this.gameObject, 1.2f);
		Instantiate (deathBurst, transform.position, Quaternion.identity);
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "Head")
			if(!invulnerable){

			{
				Debug.Log("Hit by a head!");

				if(playerNumber == 1){
					gameController.GetComponent<GameController>().playerWon = 2; // if one dies, two wins
				}
				if(playerNumber == 2){
					gameController.GetComponent<GameController>().playerWon = 1;
				}
				die();
				//this.transform.parent.GetComponent<Player>().eat();
			}
		}
	}
	
}
