using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour 
{
	public int iKey = 0;
	public List<Door> cConnectedDoors;
	public bool bConstantSwitch = true;
	public bool bIsTriggered = false;

	// Use this for initialization
	void Start () 
	{
		cConnectedDoors = new List<Door> ();
		GameObject[] agoDoors = GameObject.FindGameObjectsWithTag ("Door");
		foreach ( var goDoor in agoDoors )
		{
			Door cDoor = goDoor.GetComponent<Door> ();
			if ( cDoor.iKey == this.iKey ) 
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
		if (!bIsTriggered) 
		{
			if (col.tag == "Player") 
			{
				bIsTriggered = true;
				foreach (var cConnectedDoor in cConnectedDoors) 
				{
					cConnectedDoor.Move ();
					gameObject.GetComponent<AudioSource> ().Play ();

				}
			}
		}

	}

}
