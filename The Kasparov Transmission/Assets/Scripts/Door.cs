using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	enum DoorState
	{
		Closed 		= 0,
		Opened 		= 1,
		Closing 	= 2,
		Openning  	= 3
	}

	DoorState eCurrentState;
	public int iKey = 0;
	public float fMovementSpeed = 5.0f;
	Vector3 v3ClosedPosition;
	Vector3 v3OpenedPosition;

	// Use this for initialization
	void Start () 
	{
		v3ClosedPosition = transform.position;
		v3OpenedPosition = transform.position;
		v3OpenedPosition.y -= 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (eCurrentState) 
		{
			case DoorState.Closed:
			case DoorState.Opened:
				break;
			case DoorState.Openning:
				Openning ();
				break;
			case DoorState.Closing:
				Closing ();
				break;
		}
	}

	void Openning()
	{
		transform.position = Vector3.MoveTowards (transform.position, v3OpenedPosition, fMovementSpeed * Time.deltaTime);
		if ( transform.position ==  v3OpenedPosition && eCurrentState != DoorState.Opened)
		{
			eCurrentState = DoorState.Opened;
		}
	}
	void Closing()
	{
		transform.position = Vector3.MoveTowards (transform.position, v3ClosedPosition, fMovementSpeed * Time.deltaTime);
		if ( transform.position ==  v3OpenedPosition && eCurrentState != DoorState.Closed)
		{
			eCurrentState = DoorState.Closed;
		}
	}
	public void Open()
	{
		eCurrentState = DoorState.Openning;
	}
	public void Close()
	{
		eCurrentState = DoorState.Closing;
	}
}
