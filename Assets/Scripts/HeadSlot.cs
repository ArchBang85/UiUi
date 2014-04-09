using UnityEngine;
using System.Collections;

public class HeadSlot : MonoBehaviour {

	public bool occupied = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void flip(){

		if(occupied){
			occupied = false;
		}
		else
		{
			occupied = true;
		}
	}

	public bool state(){
		if(occupied)
		{
			return true;
		}
		else 
		{
			return false;
		}
	}

}
