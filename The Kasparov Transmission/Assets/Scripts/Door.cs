using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	enum DoorState
	{
		Stale 		= 0,
		Moving 		= 1,
	}

	public int iKey = 0;
	public float fMovementSpeed = 5.0f;
	public bool bIsReverse;

	DoorState eCurrentState;
	Vector3 v3TargetPosition;

	// Use this for initialization
	void Start () 
	{
		v3TargetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (eCurrentState) 
		{
			case DoorState.Stale:
				break;
			case DoorState.Moving:
				Moving ();
				break;
		}
	}

	void Moving()
	{
		
		transform.position = Vector3.MoveTowards (transform.position, v3TargetPosition, fMovementSpeed * Time.deltaTime);
		if ( transform.position ==  v3TargetPosition && eCurrentState != DoorState.Stale)
		{
			eCurrentState = DoorState.Stale;
		}
	}

	public void Move()
	{
		eCurrentState = DoorState.Moving;
		if (bIsReverse) {
			v3TargetPosition.y += 1;
		}
		else 
		{
			v3TargetPosition.y -= 1;
		}
	}
}
