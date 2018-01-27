﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour 
{
	public string sKey = "Default";
	public List<Door> cConnectedDoors;

	// Use this for initialization
	void Start () 
	{
		cConnectedDoors = new List<Door> ();
		GameObject[] agoDoors = GameObject.FindGameObjectsWithTag ("Door");
		foreach ( var goDoor in agoDoors )
		{
			Door cDoor = goDoor.GetComponent<Door> ();
			if ( cDoor.sKey == this.sKey ) 
			{
				cConnectedDoors.Add(cDoor);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			foreach (var cConnectedDoor in cConnectedDoors) 
			{
				cConnectedDoor.Open ();
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player") 
		{
			foreach (var cConnectedDoor in cConnectedDoors) 
			{
				cConnectedDoor.Close ();
			}
		}
	}
}
