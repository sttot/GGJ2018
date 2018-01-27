﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	int NumberBotsReached = 0;

	// Use this for initialization
	void Start () {
		NumberBotsReached = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("" + other.gameObject.tag.ToString());
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponentInParent<Player_Movement> ().ExitReached ();
			NumberBotsReached++;
		}
	}

	public int GetNumberOfBothsReachedTheExit(){
		return NumberBotsReached;
	}

}
